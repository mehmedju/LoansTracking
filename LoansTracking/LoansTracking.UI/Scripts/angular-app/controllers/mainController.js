(angular.module('app')
    .controller('mainController', ['$scope', '$location', function ($scope, $location) {
        'use strict';

        $scope.getCurrentLocation = function () {
            return $location.path();
        };
    }
    ]));

