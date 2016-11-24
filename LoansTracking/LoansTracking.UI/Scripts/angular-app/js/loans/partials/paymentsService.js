(angular.module('app')
    .service('paymentsService', function (dataService) {

        this.getPayments = function () {
            return dataService.get(paymentsUrl);
        };

        this.getPaymentsById = function (id) {
            return dataService.getById(paymentsUrl, id);
        };

        this.createPayments = function (data) {
            return dataService.post(paymentsUrl, data);
        };

        this.updatePayment = function (data,id) {
            return dataService.put(paymentsUrl, data, id);
        };

        this.deletePayment = function (id) {
            return dataService.delete(paymentsUrl, id);
        };
    })
);