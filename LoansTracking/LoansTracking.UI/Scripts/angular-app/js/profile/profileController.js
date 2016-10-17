(angular.module('app')
    .controller('profileController', ['$scope', function ($scope) {
        'use strict';

        $scope.user = {
            firstName: "Angular",
            lastName: "User",
            dateOfBirth: Date.now(),
            mobileNumber: "033 987 654",
            address: "Milana Preloga 12",
            location: "Sarajevo, BiH",
            position: "Software developer",
            company: "Mistral"
        }
    }

]));