(angular.module('app')
    .service('notesService', function (dataService) {

        this.getNotes = function () {
            return dataService.get(notesUrl);
        };

        this.createNotes = function (data) {
            return dataService.post(notesUrl, data);
        };

        this.updateNote = function (data, id) {
            return dataService.put(notesUrl+'/'+id, data);
        };

        this.deleteNote = function (id) {
            return dataService.delete(notesUrl +'/', id);
        };
    })
);