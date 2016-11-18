(angular.module('app')
    .controller('loginController', ['$scope', '$location', 'loginService', 'authService', function ($scope, $location, loginService, authService) {
        'use strict';

        angular.extend($scope, {
            showErrorMessage: false,
            user: {},
            credentials:loginService.getTemporaryCredentials()
        });

        $scope.goToSignup = function () {
            $location.path('/signup');
        }

        $scope.login = function (username, password) {
            (username === $scope.credentials.temporaryUsername && password === $scope.credentials.temporaryPassword) ?
                $location.path('/loans') : $scope.showErrorMessage = true;
            authService.putCookie(username, 1);
        }

    }
    ]));