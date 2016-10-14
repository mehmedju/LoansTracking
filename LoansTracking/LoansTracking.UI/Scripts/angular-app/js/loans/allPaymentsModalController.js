angular.module('app').controller('allPaymentsModalController', ['$scope', '$uibModalInstance', function ($scope, $uibModalInstance) {
    $scope.closeAllPaymentsModal = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);