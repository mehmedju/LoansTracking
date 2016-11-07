(angular.module('app')
    .controller('signupController', ['$scope','$location', 'signupService', function ($scope, $location, signupService) {
        'use strict';

        $scope.createAccount = function(firstName, lastName, email, password) {
            var data = {"FirstName": firstName, "LastName": lastName, "Email": email, "Password": password, "DateOfBirth": "1.1.2001"};
            signupService.signup(data).then(function (data) {
                $location.path('/login');
            });
        }
    }
    ]));