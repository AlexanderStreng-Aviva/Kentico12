window.medioClinic = window.medioClinic || {};

(function (slideshowWidget) {
    var swipers = [];

    /** The name of the data- HTML attribute that holds the Swiper GUID. */
    slideshowWidget.swiperGuidAttribute = "data-swiper-guid";

    slideshowWidget.initSwiper = function (swiperId, editMode, transitionDelay, transitionSpeed) {
        var swiperSelector = "#" + swiperId;

        var configuration = {
            loop: !editMode,
            speed: transitionSpeed,
            navigation: {
                nextEl: "#" + swiperId + " .swiper-button-next",
                prevEl: "#" + swiperId + " .swiper-button-prev"
            },
            effect: "fade",
            fadeEffect: {
                crossFade: true
            },
            autoHeight: true
        };

        if (!editMode) {
            configuration["autoplay"] = {
                delay: transitionDelay,
                disableOnInteraction: true
            };
        }

        var swiper = new Swiper(swiperSelector, configuration);
        window.medioClinic.slideshowWidget.addSwiper(swiperId, swiper);
    };
    
    slideshowWidget.getGuidFromId = function (id) {
        return id.slice(-36);
    };

    slideshowWidget.collectImageIds = function (swiper) {
        var output = [];

        for (var s = 0; s <= swiper.slides.length - 1; s++) {
            var childElement = swiper.slides[s].children[0];
            output.push(childElement.id);
        }

        return output;
    };
    
    slideshowWidget.getSwiper = function (id) {
        console.log('getswiper by id: ' + id);

        var found = swipers.filter(function (currentSwiper) {
            return currentSwiper.id === id;
        });
        if (found.length > 0) {
            return found[0];
        } else {
            return null;
        }
    };

    slideshowWidget.getCurrentSwiper = function (editor, swiperGuidAttribute) {
        console.log('getcurrentswiper editor: ' + editor + ' guidAtt: ' + swiperGuidAttribute + ' edit.GetAttri: ' + editor.getAttribute(swiperGuidAttribute));
        return window.medioClinic.slideshowWidget.getSwiper(editor.getAttribute(swiperGuidAttribute)).swiper;
    };

    slideshowWidget.addSwiper = function (id, swiper) {

        var found = window.medioClinic.slideshowWidget.getSwiper(id);

        if (!found) {
            var swiperToAdd = {
                id: id,
                swiper: swiper
            };

            swipers.push(swiperToAdd);
        }
    };

    slideshowWidget.removeSwiper = function (id) {
        for (var i = swipers.length - 1; i >= 0; i--) {
            if (swipers[i].id === id) {
                swipers.splice(i, 1);
            }
        }
    };

}(window.medioClinic.slideshowWidget = window.medioClinic.slideshowWidget || {}));