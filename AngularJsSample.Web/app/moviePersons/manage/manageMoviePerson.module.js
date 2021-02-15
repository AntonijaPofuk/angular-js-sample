(function () {

    'use strict';

    angular
        .module('manageMoviePerson', ['moviePersonsServices'])
        .controller('manageMoviePersonCtrl', manageMoviePersonCtrl);

    manageMoviePersonCtrl.$inject = ['$scope', '$http', 'moviePerson', 'moviePersonsSvc', '$state'];
    function manageMoviePersonCtrl($scope, $http, moviePerson, moviePersonsSvc, $state ) {
        
        //#region JS variables
        var vm = this;
        $("#datepicker").kendoDatePicker({
        });
        var datepicker = $("#datepicker").data("kendoDatePicker");
   
        //#endregion 


        //#region Bindable Members
        vm.moviePerson = moviePerson.data; // data is in general.routing.js
        //vm.birthday = moviePerson.data.birthday;
        //datepicker.value(new Date(vm.birthday));
        datepicker.value(new Date(2020, 9, 9));

        vm.update = saveMoviePerson;
        vm.delete = deleteMoviePerson;

   
       
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

        function deleteMoviePerson(id) {
            moviePersonsSvc.deleteMoviePerson(id).then(function () {
                $state.go("manageMoviePerson");
            }, function (error) {
                //add error handling
            });
        }

        vm.moviePerson = moviePerson ? moviePerson.data : null;

        if (vm.author) {
            //update
        }
        else {
            //create
        }

    }
       
        //#endregion



})();
