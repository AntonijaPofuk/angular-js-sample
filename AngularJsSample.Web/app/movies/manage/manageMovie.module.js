(function () {

    'use strict';

    angular
        .module('manageMovie', ['moviesServices'])
        .controller('manageMovieCtrl', manageMovieCtrl);

    manageMovieCtrl.$inject = ['$scope', '$http', 'movie', 'moviesSvc', '$state'];
    function manageMovieCtrl($scope, $http, movie, moviesSvc, $state) {

        //#region JS variables
        var vm = this;

        //#endregion 

        //#region Bindable Members
        vm.movie = movie.data; // data is in general.routing.js
        vm.save = saveMovie;
        vm.datepicker = datePicker;

        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() { }


        function saveMovie(dataItem) {
            if (vm.movie.id === undefined) {
                //create               
                moviesSvc.createMovie(vm.movie).then(function () {
                    Swal.fire('Uspješno ste kreirali novi film!')
                    $state.go("moviesOverview");
                }, function (error) {
                    Swal.fire(error.status + ': Niste uspješno dodali film!')
                });
            } else {
                //update
                moviesSvc.updateMovie(dataItem.id, vm.movie).then(function () {
                    Swal.fire('Uspješno ste ažurirali film!')
                    $state.go("moviesOverview");
                }, function (error) {
                    Swal.fire(error.status + ': Niste uspješno ažurirali film!')
                });

            }
        }

        function datePicker() {
            monthPickerConfig = {
                start: "year",
                format: "dd.MM.yyyy"
            };
        }

        $scope.selectOptions = {
            placeholder: "Odaberi žanr...",
            dataTextField: "name",
            dataValueField: "id",
            valuePrimitive: true,
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
        $scope.selectedIds = [1];
    }
    //#endregion

})();
