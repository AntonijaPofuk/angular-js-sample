﻿(function () {

    'use strict';

    angular
        .module('manageMoviePerson', ['moviePersonsServices'])
        .controller('manageMoviePersonCtrl', manageMoviePersonCtrl);

    manageMoviePersonCtrl.$inject = ['$scope', '$http', 'moviePerson', 'moviePersonsSvc', '$state'];
    function manageMoviePersonCtrl($scope, $http, moviePerson, moviePersonsSvc, $state ) {
        
        //#region JS variables
        var vm = this;

      

      
        //#endregion 


        //#region Bindable Members
        vm.moviePerson = moviePerson.data; // data is in general.routing.js
       

        vm.update = saveMoviePerson;
        vm.delete = deleteMoviePerson;
        vm.datepicker = datePicker;
      
       
        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {}

        //UPDATE
        function saveMoviePerson(dataItem) {
            moviePersonsSvc.updateMoviePerson(dataItem.id, vm.moviePerson).then(function () {
                $state.go("moviePersonsOverview");
            }, function (error) {
                //add error handling
            });
        }

        //DELETE
        function deleteMoviePerson(id) {
            moviePersonsSvc.deleteMoviePerson(id).then(function () {
                $state.go("moviePersonsOverview");
            }, function (error) {
                //add error handling
            });
        }
        function datePicker() {
            monthPickerConfig = {
                start: "year",
                format: "dd.MM.yyyy"
            };
        }

        $scope.dialog = {
            message: ""
        }
        
        $scope.showDialog = function (title, message) {
            $scope.dialog.message = message;
            $scope.deleteDialogWindow.title(title);
            $scope.deleteDialogWindow.center();
            $scope.deleteDialogWindow.open();
        }
  

    }      
        //#endregion



})();
