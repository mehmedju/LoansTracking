(angular.module('app')
    .controller('notesController', ['$scope', 'notesService', function ($scope, notesService) {
        'use strict';

        angular.extend($scope, {
            addMode: true
        });

        notesService.getNotes().then(function (data) {
            $scope.allNotes = data;
        });  

        $scope.addNewNote = function () {
            $scope.addMode = true;
        }
    }
    ]));