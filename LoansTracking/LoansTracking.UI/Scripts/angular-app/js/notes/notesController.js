(angular.module('app')
    .controller('notesController', ['$scope', 'notesService', 'authService', function ($scope, notesService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: false,
            currentUser: authService.getCookie(),
            editOnId: null,
            removeOnId: null,
            newNote: {
                id: null,
                title: "",
                text: "",
            }         
        });

        $scope.loadNotes = function () {
            notesService.getNotes(authService.getCookie()).then(function (data) {
                if (!$scope.allNotes) {
                    notificationsConfig.success("Notes loaded successfully");
                };               
                $scope.allNotes = data;
            });
        }

        $scope.loadNotes();

        $scope.$on("reloadNotes", function () {
            $scope.loadNotes();
        });
        $scope.addNewNote = function () {
            $scope.$broadcast("addNewNote");
            $scope.addMode = true;
            setTimeout($scope.$emit("reloadNotes"), 500);
        };

        $scope.updateNote = function (note) {
            notificationsConfig.success("Notes updated successfully");
            $scope.editOff();
            notesService.updateNote(note, note.id);
            setTimeout($scope.$emit("reloadNotes"),500);
        };
        $scope.removeNote = function (note) {
            notificationsConfig.success("Notes deleted successfully");
            notesService.deleteNote(note.id);
            setTimeout($scope.$emit("reloadNotes"), 500);
        };



//Edit and remove buttons
        $scope.editOn = function (note) {
            $scope.removeOff();
            $scope.editOnId = note.id;
            $scope.newNote = note;
            $scope.$emit("reloadNotes");
        }
        $scope.editOff = function () {
            $scope.editOnId = null;
            $scope.newNote = null;
            $scope.$emit("reloadNotes");
        }
        $scope.checkEdit = function (note) {
            return $scope.editOnId === note.id;
        }
        $scope.removeOn = function (note) {
            $scope.editOff();
            $scope.removeOnId = note.id;
            $scope.newNote = note;
            $scope.$emit("reloadNotes");
        }
        $scope.removeOff = function () {
            $scope.removeOnId = null;
            $scope.newNote = null;
            $scope.$emit("reloadNotes");
        }
        $scope.checkRemove = function (note) {
            return $scope.removeOnId === note.id;
        }
        $scope.checkActions = function (note) {
            return $scope.checkEdit(note) || $scope.checkRemove(note);
        }


       $scope.$emit("reloadNotes");
    }
    ]));