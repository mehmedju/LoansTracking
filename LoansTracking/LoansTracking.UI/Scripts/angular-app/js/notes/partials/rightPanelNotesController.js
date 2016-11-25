(angular.module('app')
    .controller('rightPanelNotesController', ['$scope', '$uibModal', 'notesService', function ($scope, $uibModal, notesService) {
        'use strict';

        $scope.createNote = function () {
            $scope.newNote = {
                id: $scope.currentUser,
                title: $scope.note.title,
                text: $scope.note.note,
            };
            notesService.createNotes($scope.newNote);
            window.location.reload();
        };
       
    }
    ]));