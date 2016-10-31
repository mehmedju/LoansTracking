(angular.module('app')
    .service('notesService', function (dataService) {

        this.getNotes = function () {
            return dataService.get(notesUrl);
        };
    })
);