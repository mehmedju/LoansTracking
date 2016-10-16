(angular.module('app')
    .controller('loginController', ['$scope', '$location', function ($scope, $location) {
        'use strict';

        $scope.goToSignup = function () {
            $location.path('/signup');
        }
    }
    ]));