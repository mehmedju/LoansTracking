angular.module('app').controller('allPaymentsModalController', ['$scope', '$uibModalInstance', 'loan', 'paymentsService', 'loansService', function ($scope, $uibModalInstance, loan, paymentsService, loansService) {
   
    
    $scope.reloadLoan = function (data) {
        $scope.loan = data;
        $scope.payments = $scope.loan.payments;
    };

    $scope.reloadLoan(loan);

    $scope.deletePayment = function (payment) {
        paymentsService.deletePayment(payment.id).then(function (data) {
            notificationsConfig.success("Payment deleted successfully");
            loansService.getLoansById($scope.loan.id).then(function (data) {
                $scope.reloadLoan(data);
            });
            
       
        });
    }
    $scope.closeAllPaymentsModal = function () {
        $uibModalInstance.close();
    };
}]);