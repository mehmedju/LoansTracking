(angular.module('app')
    .factory('loginService', function () {
        'use strict';

        function getTemporaryCredentials() {
            var credentials = {
                temporaryUsername: "admin",
                temporaryPassword: "password"
            }
            return credentials;
        }

        return {
            getTemporaryCredentials: getTemporaryCredentials
        }
    }
    ));