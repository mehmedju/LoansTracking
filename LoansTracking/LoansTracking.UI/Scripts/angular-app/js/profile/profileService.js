(angular.module('app')
    .service('profileService', function (dataService) {

        this.updateProfile = function (data, id) {
            dataService.put(peopleUrl + id, data);
        };

        this.getLoggedUser = function (id) {
            return dataService.getById(peopleUrl, id);
        }
    })
);