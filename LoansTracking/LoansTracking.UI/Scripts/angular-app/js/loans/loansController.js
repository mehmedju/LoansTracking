(angular.module('app')
    .controller('loansController', ['$scope', 'loansService', 'authService', function ($scope, loansService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: true,
            currentUser: authService.getCookie()
        });

        loansService.getLoans().then(function (data) {
            $scope.allLoans = data;
        });

        $scope.addNewLoan = function () {
            $scope.addMode = true;
        }
    }
    ]));

