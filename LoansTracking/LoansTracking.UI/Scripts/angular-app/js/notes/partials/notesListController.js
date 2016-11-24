(angular.module('app')
    .controller('notesListController', ['$scope', '$uibModal', 'notesService', function ($scope, $uibModal, notesService) {
        'use strict';

        $scope.editOnId;
        $scope.removeOnId;
        $scope.newNote = {
            id: null,
            title: "",
            text: "",
        }
        $scope.updateNote = function (note) {
            notesService.updateNote(note, note.id);
        };

        $scope.removeNote = function (note) {
            notesService.deleteNote(note.id);
            notesService.getNotes();
        };

        $scope.editOn = function (note) {
            $scope.removeOff();
        }

        $scope.editOn = function (note) {
            $scope.removeOff();
            $scope.editOnId = note.id;
            $scope.newNote = note;
        }

        $scope.editOff = function () {
            $scope.editOnId = null;
            $scope.newNote = null;
        }

        $scope.checkEdit = function (note) {
            return $scope.editOnId === note.id;
        }

        $scope.removeOn = function (note) {
            $scope.editOff();
            $scope.removeOnId = note.id;
            $scope.newNote = note;
        }
        $scope.removeOff = function () {
            $scope.removeOnId = null;
            $scope.newNote = null;
        }
        $scope.checkRemove = function (note) {
            return $scope.removeOnId === note.id;
        }

        $scope.checkActions = function (note) {
            return $scope.checkEdit(note) || $scope.checkRemove(note);
        }

        notesService.getNotes();
    }
    ]));