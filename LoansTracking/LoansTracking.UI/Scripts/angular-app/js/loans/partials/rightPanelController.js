(angular.module('app')
    .controller('rightPanelController', ['$scope', '$uibModal', 'loansService', 'paymentsService', 'authService', function ($scope, $uibModal, loansService, paymentsService, authService) {
        'use strict';
        
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
        $scope.$on("editLoan",function(ev, args){
            $scope.loan = args;
            $scope.editMode = true;
            $scope.addMode = false;
        });
        $scope.$on("addNewLoan", function (ev, args) {
            $scope.loan = {};
            $scope.addMode = true;
            $scope.editMode = false;
        });

        $scope.addLoan = function (loan) {
            loan.personLoanedFrom = authService.getCookie();
            loansService.createLoans(loan).then(function (data) {
                notificationsConfig.success("Loan added successfully");
                $scope.addMode = false;
                $scope.loan = {};
                $scope.$emit("reloadLoans");
            });
        };

        $scope.deleteLoan = function(id){
            loansService.deleteLoan(id).then(function (data) {
                notificationsConfig.success("Loan deleted successfully");
                $scope.addMode = false;
                $scope.editMode = false;
                $scope.loan = {};
                $scope.$emit("reloadLoans");
            });
        }
        $scope.editLoan = function (data) {
            loansService.updateLoan(data, data.id).then(function (data) {
                notificationsConfig.success("Loan updated successfully");
                $scope.addMode = false;
                $scope.editMode = false;
                $scope.loan = {};
                $scope.$emit("reloadLoans");
            });
        };

        $scope.addPayment = function (payment) {
            payment.loanId = $scope.loan.id;
            paymentsService.createPayments(payment).then(function (data) {
                notificationsConfig.success("Payment added successfully");
                $scope.showPayment = false;
                $scope.payment = {};
                loansService.getLoansById($scope.loan.id).then(function (data) {
                    $scope.loan = data;
                });
                $scope.$emit("reloadLoans");
            });
        };

        $scope.openAllPaymentsModal = function (data) {
            $uibModal.open({
                templateUrl: 'Scripts/angular-app/js/loans/partials/allPaymentsModal.html',
                controller: 'allPaymentsModalController',
                resolve: {
                    loan:data
                }
            }).result.then(function (result) {
                
            },function () {
                $scope.$emit("reloadLoans");
            });
        };
    }])
);