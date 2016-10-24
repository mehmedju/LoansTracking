(angular.module('app')
    .controller('loansController', ['$scope', 'loansService', function ($scope, loansService) {
        'use strict';

        angular.extend($scope, {
            addMode: true
        });

        loansService.getLoans().then(function (data) {
            $scope.allLoans = data;
        });

        $scope.addNewLoan = function () {
            $scope.addMode = true;
        }

    }
    ]));

