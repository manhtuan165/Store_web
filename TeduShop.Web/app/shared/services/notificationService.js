﻿(function (app) {
    app.factory('notificationService', notifictionService)

    function notifictionService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-top-right",
            "onClick": null,
            "fadeIn": 300,
            "fadeOut": 1000,
            "timeOut": 3000,
            "extendedTimeOut": 1000
        };



        function displaySuccess(message) {
            toastr.success(message);
        }

        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.displayError(err);
                });
            } else {
                toastr.error(error);
            }
        }

        function displayWarning(message) {
            toastr.warning(message);
        }

        function displayInfo(message) {
            toast.info(message);
        }

        return {
            displaySuccess: displaySuccess,
            displayError: displayError,
            displayWarning: displayWarning,
            displayInfo: displayInfo
        }
    }
})(angular.module('tedushop.common'));