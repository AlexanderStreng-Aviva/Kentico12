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
            var slideIds = window.medioClinic.slideshowWidget.collectImageIds(swiper);

            var imageGuids = slideIds.map(function (slideId) {
                return window.medioClinic.slideshowWidget.getGuidFromId(slideId);
            });

            /** Adds a new slide to the Swiper object, together with a new Dropzone object. */
            var addSlide = function ()  {
                var tempGuid = generateUuid();
                var tempId = imageGuidPrefix + tempGuid;

                var markup = buildSlideMarkup(tempId, "Drop image here or <a class='dz-clickable'>click</a> to browse");

                var activeIndexWhenAdded = swiper.slides.length > 0 ? swiper.activeIndex + 1 : 0;
                swiper.addSlide(activeIndexWhenAdded, markup);
                swiper.slideNext();

                var dropzone = new Dropzone(editor.parentElement.querySelector("div#" + tempId + ".dropzone"), {
                    acceptedFiles: window.medioClinic.dropzoneCommon.acceptedFiles,
                    maxFiles: 1,
                    url: editor.getAttribute("data-upload-url"),
                    clickable: editor.parentElement.querySelector("div#" + tempId + ".dropzone a.dz-clickable"),
                    dictInvalidFileType: "Unsupported file type. Please upload files of the following types: .bmp, .gif, .ico, .png, .wmf, .jpg, .jpeg, .tiff, .tif",
                });

                dropzone.on("success",
                    function (event) {
                        var newGuid = tempGuid;
                        var childElementIndex = getChildElementIndex(dropzone.element);
                        imageGuids.splice(childElementIndex, 1, newGuid);
                        dispatchBuilderEvent(imageGuids);
                    });
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
                                "Could not remove the slide image from page attachments.", "warning");
                            console.warn(
                                "Could not remove the slide image from page attachments.");
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
        }
    });
})();

