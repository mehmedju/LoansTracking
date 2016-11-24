(angular.module('app')
    .controller('rightPanelController', ['$scope', '$uibModal', 'loansService', function ($scope, $uibModal, loansService) {
        'use strict';
        $scope.openAllPaymentsModal = function () {
            $uibModal.open({
                templateUrl: 'Scripts/angular-app/js/loans/partials/allPaymentsModal.html',
                controller: 'allPaymentsModalController'
            });
        };

        $scope.openDatepicker1 = function () {
            $scope.datepicker1.opened = true;
        };

        $scope.openDatepicker2 = function () {
            $scope.datepicker2.opened = true;
        };

        $scope.datepicker1 = {
            opened: false
        };

        $scope.datepicker2 = {
            opened: false
        };
        $scope.createLoan = function () {
            $scope.newLoan = {
                id: 0,
                person: 12,
                firstName: $scope.loan.name,
                lastName: $scope.loan.surname,
                amount: $scope.amount,
                dueDate: Date.now
            };
            loansService.createLoans($scope.newLoan);
        };

        $scope.amount = 400;
        $scope.payments = [200, 30, 50];
    }])
);