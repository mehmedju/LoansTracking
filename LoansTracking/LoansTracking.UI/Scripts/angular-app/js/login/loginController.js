(angular.module('app')
    .controller('loginController', ['$scope', '$location', function ($scope, $location) {
        'use strict';

        angular.extend($scope, {
            showErrorMessage: false
        });

        $scope.goToSignup = function () {
            $location.path('/signup');
        }

        $scope.login = function () {
            if ($scope.user.username === "admin" && $scope.user.password === "password") {
                $location.path('/loans');
            } else {
                $scope.showErrorMessage = true;
            }
        }
    }
    ]));