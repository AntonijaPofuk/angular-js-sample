(function () {
    'use strict';
    angular
        .module('moviesOverview', ['moviesServices'])
        .controller('moviesOverviewCtrl', moviesOverviewCtrl);

    //OVERVIEW
    moviesOverviewCtrl.$inject = ['$scope', '$http', 'moviesSvc', '$state'];
    function moviesOverviewCtrl($scope, $http, moviesSvc, $state) {

        //#region JS variables
        var vm = this;
        //#endregion 

      
        //#region Bindable Members  

        vm.mainGridOptions = getMainGridOptions();
        vm.delete = deleteMovie;

        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        function activate() {
            }    
              
        //DELETE
        function deleteMovie(id) {
            moviesSvc.deleteMovie(id).then(function () {
                $state.reload();
            }, function (error) {
                console.log(error);
                //add error handling
            });
        }

        function getMainGridOptions() {

            let options = {
                dataSource: {
                    transport: {
                        read: function (options) {
                            $http.get(serviceBase + "api/movies")
                                .then(function (result) {
                                    options.success(result.data.movies);
                                }, function (error) {
                                        console.log("Error for " + serviceBase + "api/movies" + " is:" +error.status +  error.message);
                                });
                        },
                    },
                    pageSize: 5                   
                },
                pageable: true,
                selectable: true,   
                resizable: true,
                columns: [    
                    {
                        field: "name",
                        title: "Naziv",
                        width: 100,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    },
                     {
                        field: "description",
                        title: "Kratki opis",
                        width: 300,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    }
                    ,
                    {
                        field: "releaseDate",
                        title: "Datum izlaska",
                        width: 100,
                        template: "#= kendo.toString(kendo.parseDate(releaseDate, 'yyyy-MM-dd'), 'dd.MM.yyyy.') #",
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    }
                    ,
                    {
                        field: "rating",
                        title: "Ocjena",
                        width: 100,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    },
                    {
                        width: 200,
                        template: `
                        <button class="btn btn-sm btn-success" ui-sref="movieProfile({id:dataItem.id})">Profil</button>
                        <button class="btn btn-sm btn-success" ui-sref="manageMovie({id:dataItem.id})"> Ažuriraj</button>
                        <button class="btn btn-sm btn-danger" ng-click="showDialog(dataItem.id, 'Brisanje', 'Sigurno želite obrisati odabrani film?')">Obriši</button>
                        `
                    }    
                  
                ]
            };
            return options;
        }

        $scope.dialog = {
            message: ""
        }
        $scope.showDialog = function (id, title, message) {
            $scope.selectedId = id;
            $scope.dialog.message = message;
            $scope.deleteDialogWindow.title(title);
            $scope.deleteDialogWindow.center();
            $scope.deleteDialogWindow.open();
        }


        //#endregion
    };

})();
