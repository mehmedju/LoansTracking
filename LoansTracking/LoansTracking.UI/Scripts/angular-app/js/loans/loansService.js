(angular.module('app')
    .service('loansService', function (dataService) {

        this.getLoans = function () {
            return dataService.get(loansUrl);
        };

        this.getLoansById = function (id) {
            return dataService.getById(loansUrl, id);
        };

        this.createLoans = function (data) {
            return dataService.post(loansUrl, data);
        };

        this.updateLoan = function (data) {
            return dataService.put(loansUrl, data);
        };

        this.deleteLoan = function (id) {
            return dataService.delete(loansUrl, id);
        };
    })
);