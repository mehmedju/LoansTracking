(angular.module('app')
    .factory('authService', function ($cookies) {

        function putCookie(username, userId) {
            var user = { username: username, userId: userId }
            $cookies.putObject('authData', user);
        }

        function getCookie() {
            return $cookies.getObject('authData');
        }

        function removeCookie() {
            $cookies.remove('authData');
        }

        return {
            putCookie: putCookie,
            getCookie: getCookie,
            removeCookie: removeCookie
        }
    })
);