(angular.module('app')
    .controller('rightPanelNotesController', ['$scope', '$uibModal', 'notesService', 'authService', function ($scope, $uibModal, notesService, authService) {
        'use strict';

        
        $scope.$on("addNewNote", function (ev, args) {
            $scope.note = {};
            $scope.addMode = true;
        });
        $scope.addNote = function (note) {
            note.id = authService.getCookie();
            notesService.createNotes(note).then(function (data) {
                notificationsConfig.success("Note added successfully");
                $scope.addMode = false;
                $scope.note = {};
                $scope.$emit("reloadNotes");
            });
        };

        $scope.$emit("reloadNotes");
    }
    ]));