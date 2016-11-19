(angular.module('app')
    .factory('authService', function ($cookies) {

        function putCookie(id) {
            $cookies.put('authData', id);
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