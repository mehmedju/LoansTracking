(angular.module('app')
    .service('loansService', function (dataService) {

        this.getLoans = function () {
            return dataService.get(loansUrl);
        };
    })
);