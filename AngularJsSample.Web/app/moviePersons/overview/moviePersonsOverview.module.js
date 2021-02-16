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
            vm.sortVariable = getSortVariable; //function
            vm.mainGridOptions = getMainGridOptions();
            vm.dropOptions = getDropOptions();
            vm.selectedSortValue = "";     //variable
        }    
            
        function getDropOptions() {
            let dropOptions = {
                dataSource:[
                    {name:"datecreated"},
                    {name:"popularity"}
                ],          
                optionLabel: "Select one...",
                dataTextField: "name",
                dataValueField: "name"
            };
            return dropOptions;
        }

        function getSortVariable(selectedSortValue) {
            console.log("Sort value is:" + selectedSortValue);
            //vm.mainGridOptions.dataSource.sort({
            //    field: selectedSortValue,
            //    dir:"asc"
            //})
            return "id";
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
                    pageSize: 5,
                    sort: {
                        field: vm.sortVariable, dir: "asc"
                    }
                },
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
                    },
                    {
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
