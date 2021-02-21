(function () {

    'use strict';

    angular
        .module('movieProfile', ['moviesServices'])
        .controller('movieProfileCtrl', movieProfileCtrl);

    //OVERVIEW
    movieProfileCtrl.$inject = ['$scope', '$http', 'movie', 'moviesSvc','$state' ];
    function movieProfileCtrl($scope, $http, movie, moviesSvc, $state) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.movie = movie.data; // data is in general.routing.js
        vm.delete = deleteMovie;
       
        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {
         
        }

        function deleteMovie(id) {
            moviesSvc.deleteMovie(id).then(function () {
                $state.go("manageMovie");
            }, function (error) {
                //add error handling
            });
                        
                     
         }

        //#endregion

    };



})();
