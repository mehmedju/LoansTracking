(angular.module('app')
    .controller('loginController', ['$scope', '$location', function ($scope, $location) {
        'use strict';
        function goToSignup() {
            $location.path('/signup')
        }
        $scope.goToSignup = goToSignup;
    }
    ]));