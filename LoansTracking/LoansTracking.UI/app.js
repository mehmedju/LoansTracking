var app = angular.module('app', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
      when('/loans', {
          templateUrl: 'Scripts/angular-app/js/loans/loans.html',
          controller: 'loansController'
      }).
      when('/statistics', {
          templateUrl: 'Scripts/angular-app/js/statistics/statistics.html',
          controller: 'statisticsController'
      }).
      when('/notes', {
          templateUrl: 'Scripts/angular-app/js/notes/notes.html',
          controller: 'notesController'
      }).
      when('/profile', {
          templateUrl: 'Scripts/angular-app/js/profile/profile.html',
          controller: 'profileController'
      }).
      when('/login', {
          templateUrl: 'Scripts/angular-app/js/login/login.html',
          controller: 'loginController'
      }).
      otherwise({
          redirectTo: '/login'
      });
}]);