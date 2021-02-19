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
                        Swal.fire('Uspješno ste kreirali novu osobu!')
                        $state.go("moviesOverview");
                    }, function (error) {
                            Swal.fire(error.status + ': Niste uspješno dodali osobu!')
                    });                 
            } else {
                //update
                moviesSvc.updateMovie(dataItem.id, vm.movie).then(function () {
                    Swal.fire('Uspješno ste ažurirali osobu!')
                    $state.go("moviesOverview");
                }, function (error) {
                    Swal.fire(error.status + ': Niste uspješno ažurirali osobu!')
                });

            }
        }


        function datePicker() {
            monthPickerConfig = {
                start: "year",
                format: "dd.MM.yyyy"
            };
        }

        $scope.dialog = {
            message: ""
        }
        $scope.showDialog = function (title, message) {
            $scope.dialog.message = message;
            $scope.deleteDialogWindow.title(title);
            $scope.deleteDialogWindow.center();
            $scope.deleteDialogWindow.open();
        }

    }
    //#endregion

})();
