(angular.module('app')
    .controller('notesController', ['$scope', 'notesService', 'authService', '$timeout', function ($scope, notesService, authService, $timeout) {
        'use strict';

        angular.extend($scope, {
            addMode: false,
            currentUser: authService.getCookie(),
            editOnId: null,
            removeOnId: null,
            newNote: {
                id: null,
                title: "",
                text: ""
            },
            allNotes: [],
            showLoaded:true

        });

        $scope.loadNotes = function () {
            notesService.getNotes(authService.getCookie()).then(function (data) {
                if ($scope.showLoaded) {
                    notificationsConfig.success("Notes loaded successfully");
                    $scope.showLoaded = false;
                };
                $scope.allNotes = data;
            });
        }

        $scope.addNewNote = function () {
            $scope.addMode = true;
            $scope.$broadcast("addNewNote", { mode: $scope.addMode });
        };
        $scope.loadNotes();
    }
    ]));