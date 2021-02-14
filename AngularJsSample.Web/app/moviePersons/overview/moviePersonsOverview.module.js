(function () {

    'use strict';

    angular
        .module('moviePersonsOverview', ['moviePersonsServices'])
        .controller('moviePersonsOverviewCtrl', moviePersonsOverviewCtrl);

    //OVERVIEW
    moviePersonsOverviewCtrl.$inject = ['$scope', '$http'];
    function moviePersonsOverviewCtrl($scope, $http) {
        
        //#region JS variables
        var vm = this;
        //#endregion 


        //#region Bindable Members

        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        //cal for the viewModel vm
        function activate() {
            vm.mainGridOptions = getMainGridOptions();
        }

        function getProfile() {
            return "PROFILE";
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
                sortable: true,
                pageable: true,
                selectable: true,
                columns: [
                {
                    field: "id",
                    title: "#"
                },
                {
                    field: "photourl",
                    title: "Foto"
                },{
                field: "firstname",
                title: "Ime"
                },
                {
                field: "lastname",
                title: "Prezime",
                },
                {
                    field: "birthplace",
                    title: "Mjesto rođenja"
                },
              
                {
                    field: "popularity",
                    template: "\\\\\#  #: popularity #",
                    title: "Popularnost"
                    },
                {
                    field: "datecreated",
                    title: "Datum kreiranja",
                    },
                {
                    template: `
                    <button class="btn btn-success" ui-sref="moviePersonProfile({id:dataItem.id})">Profile</button>
                    <button class="btn btn-success" ui-sref="manageMoviePerson({id:dataItem.id})"> Update</button>

                        `,
                    headerTemplate: '<label> Edit </label>',
                    width: "200px"
                }
               ]
            };

        

            return options;
        }
        //#endregion

    };



})();
