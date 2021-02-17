(function () {

    'use strict';

    angular
        .module('genreProfile', ['genresServices'])
        .controller('genreProfileCtrl', genreProfileCtrl);

    //OVERVIEW
    genreProfileCtrl.$inject = ['$scope', '$http', 'genre', 'genresSvc','$state' ];
    function genreProfileCtrl($scope, $http, genre, genresSvc, $state) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.genre = genre.data; // data is in general.routing.js
        vm.delete = deleteGenre;
       
        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {
         
        }

        function deleteGenre(id) {
            genresSvc.deleteGenre(id).then(function () {
                $state.go("manageGenre");
            }, function (error) {
                //add error handling
            });
                        
                     
         }

        //#endregion

    };



})();
