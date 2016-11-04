(angular.module('app')
    .directive('loanStatus', function () {
        return {
            restrict: 'E',
            scope: {
                amount: '=',
                payments: '='
            },
            link: function(scope) {
                var paymentsSum = 0;
                for (var i = scope.payments.length; i--;) {
                    paymentsSum += scope.payments[i];
                }
                scope.loanStatus = scope.amount + paymentsSum;
            },
            template: 'Status <span class="badge red">{{loanStatus}} KM</span>'
        };
    })
);