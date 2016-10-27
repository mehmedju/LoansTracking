(angular.module('app')
    .controller('statisticsController', ['$scope', 'statisticsService', function ($scope, statisticsService) {
        'use strict';

        statisticsService.getTotalStatistics().then(function (data) {
            $scope.totalActive = data.totalActive;
            $scope.totalPaidOff = data.totalPaidOff;
        });

        statisticsService.getPaidStatistics().then(function (data) {
            $scope.allStatistics = data;
        });
    }
    ]));