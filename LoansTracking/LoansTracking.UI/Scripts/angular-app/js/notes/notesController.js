(angular.module('app')
    .controller('notesController', ['$scope', 'notesService', 'authService', function ($scope, notesService, authService) {
        'use strict';

        angular.extend($scope, {
            addMode: true,
            currentUser: authService.getCookie()
        });
        
        notesService.getNotes().then(function (data) {
            $scope.allNotes = data;
        });  

        $scope.addNewNote = function () {
            $scope.addMode = true;
        }

        
    }
    ]));