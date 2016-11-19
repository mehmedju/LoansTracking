(angular.module('app')
    .controller('loginController', ['$scope', '$location', 'loginService', 'authService', function ($scope, $location, loginService, authService) {
        'use strict';

        angular.extend($scope, {
            showErrorMessage: false,
            user: {}
        });

        $scope.goToSignup = function () {
            $location.path('/signup');
        }

        $scope.login = function (user) {
            loginService.login(user).then(function (data) {
                $scope.userID = data;
                $location.path('/loans');
                authService.putCookie($scope.userID);
            });
        };
    }
]));