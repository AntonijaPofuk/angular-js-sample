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
        
        $scope.Logout = function (genre) {
            Swal.fire({
                title: '',
                width: "60vw",
                height: "60vw",
                html: `<h1>Novi žanr</h1>    
                        <div>Ime:</div>
                        <input id="genreName" class="form-control" value="`+ genre.name + `"/>
                        <div>Opis:</div>
                        <input id="genreDesc" class="form-control"  style="max-width:100%; max-height:100%;" value="`+ genre.description + `"/>                          
                `,
                confirmButtonText: 'Spremi',
                cancelButtonText: "Odustani",
                allowOutsideClick: "true",
                focusConfirm: true,
                preConfirm: () => {
                    const genreName = Swal.getPopup().querySelector('#genreName').value
                    const genreDesc = Swal.getPopup().querySelector('#genreDesc').value
                    if (!genreName) {
                        Swal.showValidationMessage(`Please enter name`)
                    }
                    return { name: genreName, description: genreDesc }
                }
            }).then((result) => {
                genre.name = result.value.name;
                genre.description = result.value.description;
                    Swal.fire(`
                        Name: ${result.value.name}
                        Description: ${result.value.description}
                        `.trim())

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
                        width: 450,
                        template: `
                        <button class="btn btn-success" ui-sref="genreProfile({id:dataItem.id})">Profile</button>
                        <button class="btn btn-success" ui-sref="manageGenre({id:dataItem.id})"> Update</button>
                        <button class="btn btn-danger" ng-click="showDialog(dataItem.id, 'Delete Confirmation', 'Delete selected genre?')">Delete</button>
                        <button class="btn btn-danger" ng-click="Logout(dataItem)">Profil</button>


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
