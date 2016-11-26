(angular.module('app')
    .controller('loansController', ['$scope','loansService', 'authService', function ($scope, loansService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: false,
            editMode:false,
            currentUser: authService.getCookie(),
            loanShowSuccess:true
        });
        $scope.loadLoans = function () {
            loansService.getLoans(authService.getCookie()).then(function (data) {
                if (data.length === 0 && $scope.loanShowSucees) {
                    
                    notificationsConfig.success("There are no active loans ");
                }
                else {
                    $scope.allLoans = data;
                    if ($scope.loanShowSuccess) {
                        $scope.loanShowSuccess = false;
                        notificationsConfig.success("Loans loaded successfully ");
                       
                    }                 
                }
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

