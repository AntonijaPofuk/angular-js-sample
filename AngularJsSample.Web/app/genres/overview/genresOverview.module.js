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

        vm.mainGridOptions = getMainGridOptions();

        vm.delete = deleteGenre;
        
        //#endregion 

        //#region On activate 
        activate()
        //#endregion

        //#region JS functions
        //call for the viewModel vm
        function activate() {
            }    

        //DELETE
        function deleteGenre(id) {
           genresSvc.deleteGenre(id).then(function () {
                $state.reload();
            }, function (error) {
                    console.log(error);
                //add error handling
            });
        }
        
        $scope.saveGenre = function (genre) {
            if (genre == undefined) {
                genre = {};
                genre.name = "";
                genre.description = "";
            }
            Swal.fire({
                title: "",
                width: "600",
                html: ` <div class="swal-title" style:"font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif; text-align:left;">      
                        <div style=" border-bottom: 1px solid grey;">
                        <h1 style="text-align:left;">Uredi žanr</h1>
                        </div>
                        <div style="text-align:left; font-size:medium;">
                        <div>Naziv:</div>
                        <input id="genreName" class="form-control" value="`+  genre.name + `"/>
                        <div>Kratki opis:</div>
                        <textarea id="genreDesc" class="form-control" rows="4" style="max-width:100%; max-height:500%;">` +genre.description + `</textarea> 
                        </div>
                        </div
                `,
                confirmButtonText: 'Spremi',
                cancelButtonText: "Odustani",
                showCancelButton: true,
                allowOutsideClick: true,
                focusConfirm: true,
                preConfirm: () => {
                    const genreName = Swal.getPopup().querySelector('#genreName').value
                    const genreDesc = Swal.getPopup().querySelector('#genreDesc').value
                    if (!genreName) {
                        Swal.showValidationMessage(`Name is required!`)
                    }
                    return { name: genreName, description: genreDesc }
                }
            }).then((result) => {
                genre.name = result.value.name;
                genre.description = result.value.description;
                if (genre.id > 0) {
                    //update
                    genresSvc.updateGenre(genre.id, genre).then(function () {
                        $state.go("genresOverview");
                        angular.element('#grid').data("kendo-grid").dataSource.read();
                    }, function (error) {
                        //add error handling
                    });
                }
                else {
                    //create
                    genresSvc.createGenre(genre).then(function () {
                        $state.go("genresOverview");
                        angular.element('#grid').data("kendo-grid").dataSource.read();
                    }, function (error) {
                        //add error handling
                    });
                }

            })          
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
                        field: "id" , dir: "asc"
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
                        field: "datecreated",
                        title: "Datum kreiranja",
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    },
                    {
                        field: "description",
                        title: "Kreirao",
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
                        <button class="btn btn-success" ng-click="saveGenre(dataItem)">Update</button>
                        <button class="btn btn-danger" ng-click="showDialog(dataItem.id, 'Delete Confirmation', 'Delete selected genre?')">Delete</button>
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
