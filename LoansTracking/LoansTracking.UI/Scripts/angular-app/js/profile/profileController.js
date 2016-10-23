(angular.module('app')
    .controller('profileController', ['$scope', function ($scope) {
        'use strict';

        $scope.user = {
            firstName: "Angular",
            lastName: "User",
            dateOfBirth: Date.now(),
            gender: "male",
            mobileNumber: "033 987 654",
            address: "Milana Preloga 12",
            location: "Sarajevo, BiH",
            occupation: "Software developer",
            company: "Mistral",
            email: "angular@mistral.com",
            username: "Mistralko"
        }
    }

]));