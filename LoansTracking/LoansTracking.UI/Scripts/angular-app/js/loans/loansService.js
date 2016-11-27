(angular.module('app')
    .service('loansService', function (dataService) {

        this.getLoans = function (id) {
            return dataService.getById(allLoansUrl,id);
        };

        this.getLoansById = function (id) {
            return dataService.getById(loansUrl, id);
        };

        this.createLoans = function (data) {
            return dataService.post(loansUrl, data);
        };

        this.updateLoan = function (data,id) {
            return dataService.put(loansUrl, data,id);
        };

        this.deleteLoan = function (id) {
            return dataService.delete(loansUrl, id);
        };
    })
);