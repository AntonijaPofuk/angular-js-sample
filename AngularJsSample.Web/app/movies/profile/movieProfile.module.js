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
        vm.genres = getGenres;

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

    };

})();
