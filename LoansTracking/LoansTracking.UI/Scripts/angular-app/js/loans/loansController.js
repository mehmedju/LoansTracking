(angular.module('app')
    .controller('loansController', ['$scope', 'loansService', 'authService', function ($scope, loansService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: false,
            editMode:false,
            currentUser: authService.getCookie()
        });
        $scope.loadLoans = function () {
            loansService.getLoans().then(function (data) {
                $scope.allLoans = data;
            });
        }
        $scope.loadLoans();
        $scope.$on("reloadLoans", function () {
            $scope.loadLoans();
        });

        $scope.addNewLoan = function () {
            $scope.$broadcast("addNewLoan");
            $scope.editMode = false;
            $scope.addMode = true;
        }
        $scope.editLoan = function (data) {
            $scope.$broadcast("editLoan", data);
            $scope.editMode = true;
            $scope.addMode = false;
        }
    }
    ]));

