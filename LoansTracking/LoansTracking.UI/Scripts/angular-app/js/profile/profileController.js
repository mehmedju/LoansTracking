(angular.module('app')
    .controller('profileController', ['$scope', 'profileService', function ($scope, profileService) {
        'use strict';

        angular.extend($scope, {
            //change user to get currently logged in user
            user : {
                id: 3,
                firstName: "Angular",
                lastName: "User",
                dateOfBirth: new Date(),
                gender: "Male",
                mobileNumber: "033 987 654",
                address: "Milana Preloga 12",
                location: "Sarajevo, BiH",
                occupation: "Software developer",
                company: "Mistral",
                email: "angular@mistral.com",
                password: "martina"
            },
            birthDate: {
                opened: false
            },
            successful: false,
        });             

        //hardcoded - change this 
        profileService.getLoggedUser(5).then(function (data) {
            $scope.loggedUser = data;
        });

        $scope.openBirthDate = function () {
            $scope.birthDate.opened = true;
        };

        $scope.updateProfile = function (user, id) {
            profileService.updateProfile(user, id);
            $scope.successful = true;
        };
    }

]));