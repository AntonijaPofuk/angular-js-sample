(function () {
    'use strict';
    angular
        .module('moviePersonsOverview', ['moviePersonsServices'])
        .controller('moviePersonsOverviewCtrl', moviePersonsOverviewCtrl);

    //OVERVIEW
    moviePersonsOverviewCtrl.$inject = ['$scope', '$http', 'moviePersonsSvc', '$state'];
    function moviePersonsOverviewCtrl($scope, $http, moviePersonsSvc, $state) {

        //#region JS variables
        var vm = this;
        //#endregion 

      
        //#region Bindable Members

        vm.dropOptions = getDropOptions();

        vm.sortValue = getSortVariable;

        vm.sortBy = "";       

        vm.mainGridOptions = getMainGridOptions();

        vm.delete = deleteMoviePerson;


        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        function activate() {
            }    

        //DELETE
        function deleteMoviePerson(id) {
            moviePersonsSvc.deleteMoviePerson(id).then(function () {
                $state.reload();
            }, function (error) {
                    console.log(error);
                //add error handling
            });
        }

        //DROPDOWN
        function getDropOptions() {
            let dropOptions = {
                dataSource:[
                    {name:"datecreated", field: "Datum kreiranja"},
                    { name: "popularity", field: "Popularnost"}
                ],          
                optionLabel: "Odaberite opciju sortiranja",
                dataTextField: "field",
                dataValueField: "name"
            };
            return dropOptions;
        }

        function getSortVariable(a) {

            console.log("Sort value is:" + a); //getting from dropdown          

            vm.sortBy = a;

            $('#grid').data("kendo-grid").dataSource.sort({ field: vm.sortBy, dir: 'desc' });
            return a;
        }            
        
        function getMainGridOptions() {

            let options = {
                dataSource: {
                    transport: {
                        read: function (options) {
                            $http.get(serviceBase + "api/moviepersons")
                                .then(function (result) {
                                    options.success(result.data.moviePersons);
                                }, function (error) {
                                    //add error handling
                                });
                        },
                    },
                    pageSize: 5                   
                },
                pageable: true,
                selectable: true,                
                columns: [                   
                    {
                        field: "id",
                        title: "#",
                        width: 50,
                        headerAttributes: {                          
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        title: "Foto",
                        template: `        
                           <img src="#=photourl#" alt="Movie person" onerror="this.src='https://media.istockphoto.com/vectors/creative-vector-illustration-of-default-avatar-profile-placeholder-vector-id1008665336?b=1&k=6&m=1008665336&s=612x612&w=0&h=RwhZJIlY7x6Yf8pRwcKhQ_YkPiVFTfNw5Zg8FPzkv2A=';" width="20%">
                                `,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        field: "firstname",
                        title: "Ime",
                        width: 100,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        field: "lastname",
                        title: "Prezime",
                        width: 100,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        field: "birthplace",
                        title: "Mjesto rođenja",
                        width: 150,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        field: "popularity",                       
                        title: "Popularnost",
                        width: 100,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },
                    {
                        template: `
                        <button class="btn btn-sm btn-success" ui-sref="moviePersonProfile({id:dataItem.id})">Profil</button>
                        <button class="btn btn-sm btn-success" ui-sref="manageMoviePerson({id:dataItem.id})"> Ažuriraj</button>
                        <button class="btn btn-sm btn-danger" ng-click="showDialog(dataItem.id, 'Brisanje', 'Sigurno želite obrisati odabranu osobu?')">Obriši</button>
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
