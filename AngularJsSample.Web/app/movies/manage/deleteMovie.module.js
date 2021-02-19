(function () {

    'use strict';

    angular
        .module('deleteMoviePerson', ['moviePersonsServices'])
        .controller('deleteMoviePersonCtrl', deleteMoviePersonCtrl);

    //OVERVIEW
    deleteMoviePersonCtrl.$inject = ['$scope', '$http', 'moviePerson'];
    function deleteMoviePersonCtrl($scope, $http, moviePerson) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.moviePerson = moviePerson.data; // data is in general.routing.js

       
        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {
        
        }

       
        //#endregion

    };



})();
