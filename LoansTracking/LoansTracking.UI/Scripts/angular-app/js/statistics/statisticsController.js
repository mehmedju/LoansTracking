(angular.module('app')
    .controller('statisticsController', ['$scope', 'statisticsService', 'authService', function ($scope, statisticsService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: true,
            currentUser: authService.getCookie()
        });

        statisticsService.getTotalStatistics($scope.currentUser).then(function (data) {
            $scope.totalActive = data.totalActive;
            $scope.totalPaidOff = data.totalPaidOff;
        });

        statisticsService.getPaidStatistics($scope.currentUser).then(function (data) {
            $scope.allStatistics = data;
        });
    }
    ]));