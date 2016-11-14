(angular.module('app')
    .factory('authService', function ($cookies) {

        function putCookie(username) {
            $cookies.put('authData', username);
        }

        function getCookie() {
            return $cookies.get('authData');
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