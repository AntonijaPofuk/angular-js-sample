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
                        field: "name",
                        title: "name",
                        width: 50,
                        headerAttributes: {
                            style: "text-align: center"
                        },
                        attributes: {
                            style: "text-align: center;"
                        }
                    }                
                  
                ]
            };
            return options;
        }



        //#endregion
    };

})();
