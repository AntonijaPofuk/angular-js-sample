(function () {

    'use strict';

    angular
        .module('manageMovie', ['moviesServices'])
        .controller('manageMovieCtrl', manageMovieCtrl);

    manageMovieCtrl.$inject = ['$scope', '$http', 'movie', 'moviesSvc', '$state', 'moviegenres'];
    function manageMovieCtrl($scope, $http, movie, moviesSvc, $state, moviegenres) {

        //#region JS variables
        var vm = this;

        //#endregion 

        //#region Bindable Members
        vm.movie = movie.data; // data is in general.routing.js
        vm.save = saveMovie;
        vm.datepicker = datePicker;
        vm.moviegenres = moviegenres.data;

        $scope.selectedIds = [];
        $scope.oldIds = [];

        //#endregion

        //#region On activate
        activate()
        //#endregion

        //#region JS functions
        function activate() {
            if (vm.movie === undefined) {
            } else {
                angular.forEach(vm.moviegenres.moviegenres, function (value, key) {
                    $scope.selectedIds.push(value.genreId.id);
                });
                angular.forEach(vm.moviegenres.moviegenres, function (value, key) {
                    $scope.oldIds.push(value.genreId.id);
                });
            }
        }

        function saveMovie(dataItem) {
            if (vm.movie.id === undefined) {
                //create               
                moviesSvc.createMovie(vm.movie).then(function () {
                    $scope.isSame = angular.equals($scope.selectedIds, $scope.oldIds);
                    if (!$scope.isSame) {
                        $scope.toDelete = $scope.oldIds.filter(item => !$scope.selectedIds.some(other => item === other));
                        angular.forEach($scope.toDelete, function (value, key) {
                            moviesSvc.deleteMovieGenre(vm.movie.id, value).then(function (result) { }
                                , function (error) {
                                    console.log(error);
                                    //add error handling
                                }
                            );
                        });
                        $scope.toAdd = $scope.selectedIds.filter(item => !$scope.oldIds.some(other => item === other));
                        angular.forEach($scope.toAdd, function (value, key) {
                            moviesSvc.addMovieGenre({ "movieId": { "Id": vm.movie.id }, "genreId": { "Id": value } })
                                .then(function (result) { }
                                    , function (error) {
                                        console.log(error);
                                        //add error handling
                                    }
                                );
                        });

                    }
                    Swal.fire('Uspješno ste kreirali novi film!')
                    $state.go("moviesOverview");
                }, function (error) {
                    Swal.fire(error.status + ': Niste uspješno dodali film!')
                });
            } else {
                //update
                moviesSvc.updateMovie(dataItem.id, vm.movie).then(function () {
                    $scope.isSame = angular.equals($scope.selectedIds, $scope.oldIds);
                    if (!$scope.isSame) {
                        $scope.toDelete = $scope.oldIds.filter(item => !$scope.selectedIds.some(other => item === other));
                        angular.forEach($scope.toDelete, function (value, key) {
                            moviesSvc.deleteMovieGenre(vm.movie.id, value).then(function (result) { }
                                , function (error) {
                                    console.log(error);
                                    //add error handling
                                }
                            );
                        });

                        $scope.toAdd = $scope.selectedIds.filter(item => !$scope.oldIds.some(other => item === other));
                        angular.forEach($scope.toAdd, function (value, key) {
                            moviesSvc.addMovieGenre({ "movieId": { "Id": vm.movie.id }, "genreId": { "Id": value } })
                                .then(function (result) { }
                                , function (error) {
                                    console.log(error);
                                    //add error handling
                                }
                            );
                        });
                    }
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
    };
    
    //#endregion

})();
