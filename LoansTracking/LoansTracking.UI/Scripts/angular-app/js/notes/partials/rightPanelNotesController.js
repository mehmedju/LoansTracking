(angular.module('app')
    .controller('rightPanelNotesController', ['$scope', '$uibModal', 'notesService', 'authService', '$timeout', function ($scope, $uibModal, notesService, authService, $timeout) {
        'use strict';

        $scope.addNote = function (note) {
            note.id = authService.getCookie();
            notesService.createNotes(note).then(function () {
                $scope.addMode = false;
                $scope.note = {};
                $scope.loadNotes();
            });
        };

        $scope.$on('addNewNote', function (event, args) {
            $scope.addMode = args.mode;
        });
    }
    ]));