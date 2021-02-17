(function () {

    'use strict';

    angular
        .module('moviePersonProfile', ['moviePersonsServices'])
        .controller('moviePersonProfileCtrl', moviePersonProfileCtrl);

    //OVERVIEW
    moviePersonProfileCtrl.$inject = ['$scope', '$http', 'moviePerson', 'moviePersonsSvc','$state' ];
    function moviePersonProfileCtrl($scope, $http, moviePerson, moviePersonsSvc, $state) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.moviePerson = moviePerson.data; // data is in general.routing.js
        vm.delete = deleteMoviePerson;
       
        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {
         
        }

        function deleteMoviePerson(id) {
            moviePersonsSvc.deleteMoviePerson(id).then(function () {
                $state.go("manageMoviePerson");
            }, function (error) {
                //add error handling
            });
                        
                     
         }

        //#endregion

    };



})();
