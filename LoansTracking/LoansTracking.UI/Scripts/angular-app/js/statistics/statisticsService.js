(angular.module('app')
    .service('statisticsService', function (dataService) {

        this.getTotalStatistics = function (currentUserId) {
            return dataService.getById(totalStatisticsUrl, currentUserId);
        };

        this.getPaidStatistics = function (currentUserId) {
            return dataService.getById(paidOffStatitsticsUrl, currentUserId);
        };
    })
);