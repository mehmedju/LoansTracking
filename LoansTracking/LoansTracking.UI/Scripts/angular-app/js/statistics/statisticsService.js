(angular.module('app')
    .service('statisticsService', function (dataService) {

        this.getTotalStatistics = function () {
            return dataService.get(totalStatisticsUrl);
        };

        this.getPaidStatistics = function () {
            return dataService.get(paidOffStatitsticsUrl);
        };
    })
);