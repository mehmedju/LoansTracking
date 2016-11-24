(angular.module('app')
    .service('loginService', function (dataService) {
        
        //function getTemporaryCredentials() {
        //    var credentials = {
        //        temporaryUsername: "admin",
        //        temporaryPassword: "password"
        //    }
        //    return credentials;
        //}

        //return {
        //    getTemporaryCredentials: getTemporaryCredentials
        //}

        this.login = function (data) {
            return dataService.post(loginUrl, data);
        };

    }
));