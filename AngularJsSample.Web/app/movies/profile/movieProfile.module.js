﻿(function () {

    'use strict';

    angular
        .module('movieProfile', ['moviesServices'])
        .controller('movieProfileCtrl', movieProfileCtrl);

    //OVERVIEW
    movieProfileCtrl.$inject = ['$scope', '$http', 'movie', 'moviesSvc', '$state', 'moviegenres' ];
    function movieProfileCtrl($scope, $http, movie, moviesSvc, $state, moviegenres) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.movie = movie.data; // data is in general.routing.js
        vm.delete = deleteMovie;
        vm.moviegenres = moviegenres.data;

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

    
    $scope.selectOptions = {
        placeholder: "Odaberi žanr...",
        dataTextField: "genreId.id",
        dataValueField: "genreId.id",
        valuePrimitive: true,
        value: $scope.selectedIds,
        autoBind: false,
        dataSource: {
            transport: {
                read: function (options) {
                    $http.get(serviceBase + "api/moviegenres/"+movie.data.id) 
                        .then(function (result) {
                            options.success(result.data.moviegenres);
                        }, function (error) {
                                console.log("Error for " + serviceBase + "api/moviegenres" + " is:" + error.status + error.message);
                        });
                },
            },
        }
        };    

        $scope.selectedIds = [];      
        angular.forEach(vm.moviegenres.moviegenres, function (value, key) {
            $scope.selectedIds.push(value.genreId.id);

        }); 

    };

})();
