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

        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        function activate() {
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
                                        console.log("Error for " + serviceBase + "api/movies" + " is:" + error);
                                });
                        },
                    },
                    pageSize: 5                   
                },
                pageable: true,
                selectable: true,                
                columns: [    
                    {
                        field: "name",
                        title: "Naziv",
                        width: 50,
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
                        width: 50,
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
                        width: 50,
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
                        width: 50,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    },
                    {
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



        //#endregion
    };

})();
