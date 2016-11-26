(angular.module('app')
    .controller('signupController', ['$scope','$location', 'signupService', function ($scope, $location, signupService) {
        'use strict';

        $scope.createAccount = function (firstName, lastName, email, password) {
            var data = { "FirstName": firstName, "LastName": lastName, "Email": email, "Password": password, "DateOfBirth": "1.1.2001" };
            signupService.signup(data).then(function (data) {
                $location.path('/login');
            });
        }

        angular.extend($scope, {           
            user: {},
            confirmPassword: "",
            showErrorMessage: false,
            birthDate: {
                opened: false
            }
        });

        $scope.openBirthDate = function () {
            $scope.birthDate.opened = true;
        };

        $scope.signUp = function (user) {
            if ($scope.confirmPassword != user.password) $scope.showErrorMessage = true;
            else {
                signupService.signup(user).then(function (data) {
                    notificationsConfig.success("Account created successfully ");
                    $location.path('/login');
                });
            }   
        };
    }
]));