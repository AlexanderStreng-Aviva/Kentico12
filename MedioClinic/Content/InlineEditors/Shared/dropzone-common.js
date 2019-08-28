window.medioClinic = window.medioClinic || {};

(function (dropzoneCommon) {
    dropzoneCommon.acceptedFiles = ".bmp, .gif, .ico, .png, .wmf, .jpg, .jpeg, .tiff, .tif";

    dropzoneCommon.processErrors = function (statusCode, localizationService) {
        var errorFlag = "error";

        if (statusCode >= 500) {
            medioClinic.showMessage("The upload of the image failed. Please contact the system administrator.", errorFlag);
        } else if (statusCode === 422) {
            medioClinic.showMessage("The uploaded image could not be processed. Please contact the system administrator.", errorFlag);
        } else {
            medioClinic.showMessage("An unknown error happened. Please contact the system administrator.", errorFlag);
        }
    };
}(window.medioClinic.dropzoneCommon = window.medioClinic.dropzoneCommon || {}));