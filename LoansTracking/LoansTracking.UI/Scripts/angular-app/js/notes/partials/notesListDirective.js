(angular.module('app')
    .directive('notesList', function () {
        return {
            restrict: 'E',
            scope: {
                allNotes: '=',
                search:'='
            },
            templateUrl: 'Scripts/angular-app/js/notes/partials/notesList.html'
        };
    })
);