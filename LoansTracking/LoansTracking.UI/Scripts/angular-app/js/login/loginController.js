(angular.module('app')
    .controller('loginController', ['$scope', '$location', function ($scope, $location) {
        'use strict';

        angular.extend($scope, {
            showErrorMessage: false,
            user: {},
            temporaryUsername: "admin",
            temporaryPassword: "password"
        });

        $scope.goToSignup = function () {
            $location.path('/signup');
        }

        $scope.login = function (username, password) {
            (username === $scope.temporaryUsername && password === $scope.temporaryPassword) ?
                $location.path('/loans') : $scope.showErrorMessage = true;
        }
    }
    ]));