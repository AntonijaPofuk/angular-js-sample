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
      
        vm.mainGridOptions = getMainGridOptions();
        vm.dropOptions = getDropOptions();

        vm.selectedSortValue = getSortVariable; 

        vm.sortVariable = putSortVariable();
        vm.catchedSortVariable = getSortVariable;

        //var sort = [{field: "firstname", dir: "asc"}];
        var sort = [{ field: vm.selectedSortValue, dir: "asc" }];
        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        //cal for the viewModel vm
        function activate() { }    

        function getSortVariable(a) {            
            console.log("Sort value is:" + a); //getting from dropdown
            return a;
            vm.mainGridOptions.refresh()
        }
        
        function getDropOptions() {
            let dropOptions = {
                dataSource:[
                    {name:"datecreated"},
                    {name:"popularity"}
                ],          
                optionLabel: "Select sorting value",
                dataTextField: "name",
                dataValueField: "name"
            };
            return dropOptions;
        }

        function putSortVariable() { //sending into grid.sort
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
                    sort: sort
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
