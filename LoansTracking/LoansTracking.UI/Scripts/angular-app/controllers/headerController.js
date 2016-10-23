(angular.module('app')
    .controller('headerController', ['$scope', '$location', function ($scope, $location) {
        'use strict';

        $scope.getCurrentLocation = function () {
            return $location.path();
        };
    }
    ]));

