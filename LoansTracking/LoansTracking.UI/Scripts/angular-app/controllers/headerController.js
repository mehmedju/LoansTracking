(angular.module('app')
    .controller('headerController', ['$scope', '$location','authService', function ($scope, $location,authService) {
        'use strict';

        $scope.getCurrentLocation = function () {
            return $location.path();
        };

        $scope.signOut=function() {
            authService.removeCookie();
            $location.path('/login');
        }
    }
    ]));

