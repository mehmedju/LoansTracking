(angular.module('app')
    .controller('profileController', ['$scope', 'profileService', 'authService', function ($scope, profileService, authService) {
        'use strict';

        angular.extend($scope, {
            user: {},
            birthDate: {
                opened: false
            },
            successful: false,
        });

        //get id of logged user from cookies
        $scope.loggedUserID = authService.getCookie();
        profileService.getLoggedUser($scope.loggedUserID).then(function (data) {
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