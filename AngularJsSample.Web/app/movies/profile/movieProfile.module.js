(function () {

    'use strict';

    angular
        .module('movieProfile', ['moviesServices'])
        .controller('movieProfileCtrl', movieProfileCtrl);

    //OVERVIEW
    movieProfileCtrl.$inject = ['$scope', '$http', 'movie', 'moviesSvc', '$state', 'moviegenres'];
    function movieProfileCtrl($scope, $http, movie, moviesSvc, $state, moviegenres) {

        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members
        vm.movie = movie.data; // data is in general.routing.js
        vm.delete = deleteMovie;
        vm.moviegenres = moviegenres.data;

        $("#listView").kendoListView({
            dataSource: vm.moviegenres.moviegenres,
            template: "<div class='itemList ridge'>#:genreId.name#</div>"
        });


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
            dataTextField: "name",
            dataValueField: "id",
            valuePrimitive: true,
            value: $scope.selectedIds,
            autoBind: false,
            dataSource: {
                transport: {
                    read: function (options) {            
                        $http.get(serviceBase + "api/genres")
                            .then(function (result) {
                                options.success(result.data.genres);
                            }, function (error) {
                                console.log("Error for " + serviceBase + "api/genres" + " is:" + error.status + error.message);
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
