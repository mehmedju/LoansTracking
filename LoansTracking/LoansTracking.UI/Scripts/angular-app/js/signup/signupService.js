(angular.module('app')
    .service('signupService', function (dataService) {

        this.signup = function (data) {
            return dataService.post(peopleUrl, data);
        };
    })
);