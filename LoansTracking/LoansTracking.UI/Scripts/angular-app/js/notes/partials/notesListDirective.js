(angular.module('app')
    .directive('notesList', function (notesService, authService) {
        return {
            restrict: 'E',
            scope: {
                notes: '=',
                search: '='
            },
            templateUrl: 'Scripts/angular-app/js/notes/partials/notesList.html',
            link: function (scope, attrs, el) {

                scope.updateNote = function (note) {
                    scope.editOff();
                    notesService.updateNote(note, note.id).then(function () {
                        refreshData();
                    });
                };

                scope.removeNote = function (note) {
                    notesService.deleteNote(note.id).then(function () {
                        refreshData();
                    });
                };

                scope.editOn = function (note) {
                    scope.removeOff();
                    scope.editOnId = note.id;
                    scope.newNote = note;
                }

                scope.editOff = function () {
                    scope.editOnId = null;
                    scope.newNote = null;
                    refreshData();
                }

                scope.checkEdit = function (note) {
                    return scope.editOnId === note.id;
                }

                scope.removeOn = function (note) {
                    scope.editOff();
                    scope.removeOnId = note.id;
                    scope.newNote = note;
                }

                scope.removeOff = function () {
                    scope.removeOnId = null;
                    scope.newNote = null;
                    refreshData();
                }

                scope.checkRemove = function (note) {
                    return scope.removeOnId === note.id;
                }

                scope.checkActions = function (note) {
                    return scope.checkEdit(note) || scope.checkRemove(note);
                }

                function refreshData() {
                    notesService.getNotes(authService.getCookie()).then(function (data) {
                        scope.notes = data;
                    });
                }
            }
        };
    })
);