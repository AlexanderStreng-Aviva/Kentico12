(function () {
    window.kentico.pageBuilder.registerInlineEditor("slideshow-editor", {

        init: function (options) {
            var imageGuidPrefix = "i-";
            var editor = options.editor;

            var swiper = window.medioClinic
                .slideshowWidget
                .getCurrentSwiper(editor, window.medioClinic.slideshowWidget.swiperGuidAttribute);
            
            var plusButton = editor.parentElement.querySelector("ul.kn-slideshow-buttons .kn-swiper-plus");
            var minusButton = editor.parentElement.querySelector("ul.kn-slideshow-buttons .kn-swiper-minus");

            // Image GUID retrieval: Alternative 2 (begin)
            var imageGuids = editor.getAttribute("data-image-guids").split(";");
            imageGuids.splice(-1, 1);

            /** Adds a new slide to the Swiper object, together with a new Dropzone object. */
            var addSlide = function () {
                var tempGuid = generateUuid();
                var tempId = imageGuidPrefix + tempGuid;

                var markup = buildSlideMarkup(tempId, "Drop image here or <a class='dz-clickable'>click</a> to browse");

                var activeIndexWhenAdded = swiper.slides.length > 0 ? swiper.activeIndex + 1 : 0;
                imageGuids.splice(activeIndexWhenAdded, 0, tempGuid);
                swiper.addSlide(activeIndexWhenAdded, markup);
                swiper.slideNext();

                var previewTemplate = "<div class=\"dz-preview dz-file-preview\"><img data-dz-thumbnail /></div>";
                var enforceDimensions = editor.getAttribute("data-enforce-dimensions") === "true";
                var computedStyle = window.getComputedStyle(editor.parentElement);
                var computedWidth = computedStyle.width.substring(0, computedStyle.width.length - 2);
                var computedHeight = computedStyle.height.substring(0, computedStyle.height.length - 2);
                var width = enforceDimensions ? editor.getAttribute("data-width") : Math.round(computedWidth);
                var height = enforceDimensions ? editor.getAttribute("data-height") : Math.round(computedHeight);

                var dropzone = new Dropzone(editor.parentElement.querySelector("div#" + tempId + ".dropzone"), {
                    acceptedFiles: window.medioClinic.dropzoneCommon.acceptedFiles,
                    maxFiles: 1,
                    url: editor.getAttribute("data-upload-url"),
                    clickable: editor.parentElement.querySelector("div#" + tempId + ".dropzone a.dz-clickable"),

                    dictInvalidFileType: options.localizationService.getString("InlineEditors.Dropzone.InvalidFileType"),

                    previewsContainer: swiper.slides[activeIndexWhenAdded],
                    previewTemplate: previewTemplate,
                    thumbnailWidth: width,
                    thumbnailHeight: height
                });

                dropzone.on("success",
                    function (event) {
                        var content = JSON.parse(event.xhr.response);
                        var newGuid = content.guid;
                        replaceId(dropzone.element, imageGuidPrefix + newGuid);
                        hideDropzoneLabels(dropzone.element);
                        var childElementIndex = getChildElementIndex(dropzone.element);
                        imageGuids.splice(childElementIndex, 1, newGuid);
                        dispatchBuilderEvent(imageGuids);
                    });

                dropzone.on("error",
                    function (event) {
                        window.medioClinic.dropzoneCommon.processErrors(event.xhr.status, options.localizationService);
                    });
            };

            var replaceId = function (htmlElement, newId) {
                htmlElement.id = newId;
            };

            var hideDropzoneLabels = function (dropzoneElement) {
                dropzoneElement.querySelector("a.dz-clickable").style.display = "none";
                dropzoneElement.querySelector(".dz-message").style.display = "none";
            };

            var removeSlide = function ()  {
                var slideChildElement = swiper.slides[swiper.activeIndex].children[0];
                var childElementIndex = getChildElementIndex(slideChildElement);

                if (imageGuids[childElementIndex]) {
                    var body = "attachmentGuid=" + imageGuids[childElementIndex];
                    var xhr = new XMLHttpRequest();
                    xhr.open("DELETE", editor.getAttribute("data-delete-url"), true);
                    xhr.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");

                    xhr.onreadystatechange = function () {
                        if (xhr.readyState === 4 && xhr.status === 204) {
                            window.medioClinic.showMessage(
                                kentico.localization.strings["InlineEditors.SlideshowEditor.ImageNotDeleted"], "warning");
                            console.warn(
                                kentico.localization.strings["InlineEditors.SlideshowEditor.ImageNotDeleted"]);
                        }
                    };

                    xhr.send(body);
                }

                imageGuids.splice(childElementIndex, 1);
                swiper.removeSlide(swiper.activeIndex);
                dispatchBuilderEvent(imageGuids);
            };
            
            var getChildElementIndex = function (dropzoneElement) {
                return Array.prototype.slice.call(dropzoneElement.parentElement.parentElement.children)
                    .indexOf(dropzoneElement.parentElement);
            };

            var buildSlideMarkup = function (id, dropText) {
                return "<div class=\"swiper-slide dropzone-previews\"><div class=\"dropzone\" id=\""
                    + id + "\"><div class=\"dz-message\">" + dropText + "</div></div></div>";
            };

            var generateUuid = function () {
                return "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
                    var r = Math.random() * 16 | 0, v = c === "x" ? r : r & 0x3 | 0x8;

                    return v.toString(16);
                });
            };

            var dispatchBuilderEvent = function (imageGuids) {
                var customEvent = new CustomEvent("updateProperty",
                    {
                        detail: {
                            name: options.propertyName,
                            value: imageGuids,
                        }
                    });

                editor.dispatchEvent(customEvent);
            };
            
            plusButton.addEventListener("click", addSlide);
            minusButton.addEventListener("click", removeSlide);
        },

        destroy: function (options) {
            var swiper = window.medioClinic
                .slideshowWidget
                .getCurrentSwiper(options.editor, window.medioClinic.slideshowWidget.swiperGuidAttribute);

            if (swiper) {
                var slideIds = window.medioClinic.slideshowWidget.collectImageIds(swiper);

                if (slideIds && Array.isArray(slideIds)) {
                    slideIds.forEach(function (dropzoneId) {
                        var dropzoneElement = document.getElementById(dropzoneId);

                        if (dropzoneElement && dropzoneElement.dropzone) {
                            dropzoneElement.dropzone.destroy();
                        }
                    });
                }

                window.medioClinic.slideshowWidget.removeSwiper(swiper.el.id);
                swiper.destroy();
            }
        }

    });
})();

