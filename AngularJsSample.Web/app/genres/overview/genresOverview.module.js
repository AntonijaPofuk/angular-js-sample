(function () {
    'use strict';
    angular
        .module('genresOverview', ['genresServices'])
        .controller('genresOverviewCtrl', genresOverviewCtrl);

    //OVERVIEW
    genresOverviewCtrl.$inject = ['$scope', '$http', 'genresSvc', '$state'];
    function genresOverviewCtrl($scope, $http, genresSvc, $state) {

        //#region JS variables
        var vm = this;
        //#endregion 

      
        //#region Bindable Members

        vm.dropOptions = getDropOptions();

        vm.sortValue = getSortVariable;

        vm.sortBy = "";       
        //vm.sortBy = getSortVariable;

        vm.mainGridOptions = getMainGridOptions();

        vm.delete = deleteMoviePerson;

        //var sort = [{field: "firstname", dir: "asc"}];

        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        //call for the viewModel vm
        function activate() {
            }    

        //DELETE
        function deleteMoviePerson(id) {
            genresSvc.deleteMoviePerson(id).then(function () {
                $state.reload();
                //$state.go("genresOverview");
            }, function (error) {
                    console.log(error);
                //add error handling
            });
        }

        //DROPDOWN
        function getDropOptions() {
            let dropOptions = {
                dataSource:[
                    {name:"datecreated", field: "Date created"},
                    { name: "popularity", field: "Popularity"}
                ],          
                optionLabel: "Select sorting value",
                dataTextField: "field",
                dataValueField: "name"
            };
            return dropOptions;
        }

        function getSortVariable(a) {

            console.log("Sort value is:" + a); //getting from dropdown          

            vm.sortBy = a;

            angular.element('#grid').data("kendo-grid").dataSource.read();

            return a;
        }            
        
        function getMainGridOptions() {

            let options = {
                dataSource: {
                    transport: {
                        read: function (options) {
                            $http.get(serviceBase + "api/genres")
                                .then(function (result) {
                                    options.success(result.data.genres);
                                }, function (error) {
                                    //add error handling
                                });
                        },
                    },
                    pageSize: 5,
                    sort: {
                        field: vm.sortBy , dir: "desc"
                    }
                },
                pageable: true,
                selectable: true,                
                columns: [                   
                    {
                        field: "id",
                        title: "#",
                        width: 80,
                        headerAttributes: {                          
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },                    
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
                        title: "Opis",
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        } 
                    },                   
                    {
                        width: 450,
                        template: `
                        <button class="btn btn-success" ui-sref="genreProfile({id:dataItem.id})">Profile</button>
                        <button class="btn btn-success" ui-sref="manageMoviePerson({id:dataItem.id})"> Update</button>
                        <button class="btn btn-danger" ng-click="showDialog(dataItem.id, 'Delete Confirmation', 'Delete selected person?')">Delete</button>
                        `,
                        width: "200px"
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
