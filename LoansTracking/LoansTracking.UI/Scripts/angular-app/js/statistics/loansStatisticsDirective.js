(angular.module('app')
    .directive('activeLoans', function () {
        return {
            restrict: 'AE',
            scope: {
                amount: '=',
            },
            templateUrl: '../Scripts/angular-app/js/statistics/activeLoans.html'
        };
    })
    .directive('returnedLoans', function () {
        return {
            restrict: 'AE',
            scope: {
                amount: '=',
            },
            templateUrl: '../Scripts/angular-app/js/statistics/returnedLoans.html'
        };
    })
);