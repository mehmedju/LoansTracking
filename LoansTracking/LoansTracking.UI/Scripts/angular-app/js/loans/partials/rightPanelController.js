(angular.module('app')
    .controller('rightPanelController', ['$scope', '$uibModal', function ($scope, $uibModal) {
        'use strict';
        $scope.openAllPaymentsModal = function () {
            var modalInstance = $uibModal.open({
                templateUrl: 'allPaymentsModalContent.html',
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
    }
    ]));