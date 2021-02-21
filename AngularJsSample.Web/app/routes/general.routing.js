(function () {

    'use strict';

    angular
        .module('general.routing', [])
        .config(config);

    config.$inject = ['$stateProvider'];
    function config(
        $stateProvider) {

        $stateProvider
            .state('dashboard', {
                url: "/",
                controller: "dashboardCtrl",
                controllerAs: "vm",
                templateUrl: "app/dashboard/partials/dashboard.html",
                resolve: {
                    loginRequired: loginRequired,
                    dashboardServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "dashboardServices",
                            files: [
                                "app/dashboard/dashboardServices.module.js"
                            ]
                        });
                    },
                    dashboard: function ($ocLazyLoad, dashboardServices) {
                        return $ocLazyLoad.load({
                            name: "dashboard",
                            files: [
                                "app/dashboard/dashboard.module.js"
                            ]
                        });
                    }

                }
            })
            .state('authorsOverview', {
                url: "/authors",
                controller: "authorsOverviewCtrl",
                controllerAs: "vm",
                templateUrl: "app/authors/partials/authorsOverview.html",
                resolve: {
                    loginRequired: loginRequired,
                    authorsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "authorsServices",
                            files: [
                                "app/authors/authorsServices.module.js"
                            ]
                        });
                    },
                    authors: function ($ocLazyLoad, authorsServices) {
                        return $ocLazyLoad.load({
                            name: "authors",
                            files: [
                                "app/authors/authors.module.js"
                            ]
                        });
                    }

                }
            })


            .state('moviePersonsOverview', {
                url: "/moviepersons",
                controller: "moviePersonsOverviewCtrl",
                controllerAs: "vm",
                templateUrl: "app/moviePersons/overview/overview.html",
                resolve: {
                    loginRequired: loginRequired,
                    moviePersonsServices: function ($ocLazyLoad) { // loading services
                        return $ocLazyLoad.load({
                            name: "moviePersonsServices",
                            files: [
                                "app/moviePersons/moviePersonsServices.module.js"
                            ]
                        });
                    },
                    // loading controller
                    moviePersonsOverview: function ($ocLazyLoad, moviePersonsServices) {
                        return $ocLazyLoad.load({
                            name: "moviePersonsOverview",
                            files: [
                                "app/moviePersons/overview/moviePersonsOverview.module.js"
                            ]
                        });
                    }

                }
            })


            .state('moviesOverview', {
                url: "/movies",
                controller: "moviesOverviewCtrl",
                controllerAs: "vm",
                templateUrl: "app/movies/overview/overview.html",
                resolve: {
                    loginRequired: loginRequired,
                    moviesServices: function ($ocLazyLoad) { // loading services
                        return $ocLazyLoad.load({
                            name: "moviesServices",
                            files: [
                                "app/movies/moviesServices.module.js"
                            ]
                        });
                    },
                    // loading controller
                    moviesOverview: function ($ocLazyLoad, moviesServices) {
                        return $ocLazyLoad.load({
                            name: "moviesOverview",
                            files: [
                                "app/movies/overview/moviesOverview.module.js"
                            ]
                        });
                    }

                }
            })

            .state('genresOverview', {
                url: "/genres",
                controller: "genresOverviewCtrl",
                controllerAs: "vm",
                templateUrl: "app/genres/overview/overview.html",
                resolve: {
                    loginRequired: loginRequired,
                    genresServices: function ($ocLazyLoad) { // loading services
                        return $ocLazyLoad.load({
                            name: "genresServices",
                            files: [
                                "app/genres/genresServices.module.js"
                            ]
                        });
                    },
                    // loading controller
                    genresOverview: function ($ocLazyLoad, genresServices) {
                        return $ocLazyLoad.load({
                            name: "genresOverview",
                            files: [
                                "app/genres/overview/genresOverview.module.js"
                            ]
                        });
                    }

                }
            })

            .state('authorProfile', {
                url: "/authors/:id",
                controller: "authorProfileCtrl",
                controllerAs: "vm",
                templateUrl: "app/authors/partials/profile.html",
                resolve: {
                    loginRequired: loginRequired,
                    authorsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "authorsServices",
                            files: [
                                "app/authors/authorsServices.module.js"
                            ]
                        });
                    },
                    authors: function ($ocLazyLoad, authorsServices) {
                        return $ocLazyLoad.load({
                            name: "authors",
                            files: [
                                "app/authors/authors.module.js"
                            ]
                        });
                    }

                }
            })

            .state('moviePersonProfile', {
                url: "/moviepersons/:id",
                controller: "moviePersonProfileCtrl",
                controllerAs: "vm",
                templateUrl: "app/moviePersons/profile/profile.html",
                resolve: { //loading services
                    loginRequired: loginRequired,
                    moviePersonsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "moviePersonsServices",
                            files: [
                                "app/moviePersons/moviePersonsServices.module.js"
                            ]
                        });
                    },

                    moviePerson: function (moviePersonsServices, moviePersonsSvc, $stateParams) { //geting id from route
                        return moviePersonsSvc.getMoviePerson($stateParams.id);
                        //calling services
                    }, //geting value from route

                  
                    moviePersonProfile: function ($ocLazyLoad, moviePersonsServices, moviePerson ) {
                        return $ocLazyLoad.load({ //loading controller
                            name: "moviePersonProfile",
                            files: [
                                "app/moviePersons/profile/moviePersonProfile.module.js"
                            ]
                        });
                    }

                }
            })

            .state('genreProfile', {
                url: "/moviepersons/:id",
                controller: "genreProfileCtrl",
                controllerAs: "vm",
                templateUrl: "app/genres/profile/profile.html",
                resolve: { //loading services
                    loginRequired: loginRequired,
                    genresServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "genresServices",
                            files: [
                                "app/genres/genresServices.module.js"
                            ]
                        });
                    },

                    genre: function (genresServices, genresSvc, $stateParams) { //geting id from route
                        return genresSvc.getGenre($stateParams.id);
                        //calling services
                    }, //geting value from route


                    genreProfile: function ($ocLazyLoad, genresServices, genre) {
                        return $ocLazyLoad.load({ //loading controller
                            name: "genreProfile",
                            files: [
                                "app/genres/profile/genreProfile.module.js"
                            ]
                        });
                    }

                }
            })

            .state('movieProfile', {
                url: "/movies/:id",
                controller: "movieProfileCtrl",
                controllerAs: "vm",
                templateUrl: "app/movies/profile/profile.html",
                resolve: { //loading services
                    loginRequired: loginRequired,
                    moviesServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "moviesServices",
                            files: [
                                "app/movies/moviesServices.module.js"
                            ]
                        });
                    },
                    movie: function (moviesServices, moviesSvc, $stateParams) { //geting id from route
                        return moviesSvc.getMovie($stateParams.id);
                        //calling services
                    }, //geting value from route
                    movieProfile: function ($ocLazyLoad, moviesServices, movie) {
                        return $ocLazyLoad.load({ //loading controller
                            name: "movieProfile",
                            files: [
                                "app/movies/profile/movieProfile.module.js"
                            ]
                        });
                    }

                }
            })

            .state('manageMoviePerson', {
                url: "/moviepersons/update/:id",
                controller: "manageMoviePersonCtrl",
                controllerAs: "vm",
                templateUrl: "app/moviePersons/manage/manageMoviePerson.html",
                resolve: { 
                    loginRequired: loginRequired,
                    moviePersonsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "moviePersonsServices",
                            files: [
                                "app/moviePersons/moviePersonsServices.module.js"
                            ]
                        });
                    },

                    moviePerson: function (moviePersonsServices, moviePersonsSvc, $stateParams) { 
                        return moviePersonsSvc.getMoviePerson($stateParams.id);
                    }, 

                    manageMoviePerson: function ($ocLazyLoad, moviePersonsServices, moviePerson) {
                        return $ocLazyLoad.load({ 
                            name: "manageMoviePerson",
                            files: [
                                "app/moviePersons/manage/manageMoviePerson.module.js"
                            ]
                        });
                    }

                }
            })


            .state('createMoviePerson', {
                url: "/moviepersons/new",
                controller: "manageMoviePersonCtrl",
                controllerAs: "vm",
                templateUrl: "app/moviePersons/manage/manageMoviePerson.html",
                resolve: {
                    loginRequired: loginRequired,
                    moviePersonsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "moviePersonsServices",
                            files: [
                                "app/moviePersons/moviePersonsServices.module.js"
                            ]
                        });
                    },
                    moviePerson: function () {
                        return {};
                    },
                    manageMoviePerson: function ($ocLazyLoad, moviePersonsServices, moviePerson ) {
                        return $ocLazyLoad.load({
                            name: "manageMoviePerson",
                            files: [
                                "app/moviePersons/manage/manageMoviePerson.module.js"
                            ]
                        });
                    }
                }
            })
           

            .state('newAuthor', {
                url: "/author/new",
                controller: "authorManageCtrl",
                controllerAs: "vm",
                templateUrl: "app/authors/partials/manageAuthor.html",
                cache: false,
                resolve: {
                    loginRequired: loginRequired,
                    author: function () {
                        return null;
                    },
                    authorsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "authorsServices",
                            files: [
                                "app/authors/authorsServices.module.js"
                            ]
                        });
                    },
                    authors: function ($ocLazyLoad, authorsServices, author) {
                        return $ocLazyLoad.load({
                            name: "authors",
                            files: [
                                "app/authors/authors.module.js"
                            ]
                        });
                    }

                }
            })

            .state('updateMoviePerson', {
                url: "/moviepersons/:id",
                controller: "updateMoviePersonCtrl",
                controllerAs: "vm",
                templateUrl: "app/moviePersons/manage/updateMoviePerson.html",
                resolve: { //loading services
                    loginRequired: loginRequired,
                    moviePersonsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "moviePersonsServices",
                            files: [
                                "app/moviePersons/moviePersonsServices.module.js"
                            ]
                        });
                    },
                    moviePerson: function (moviePersonsServices, moviePersonsSvc, $stateParams) { //geting id from route
                        return moviePersonsSvc.getMoviePerson($stateParams.id); //calling services 
                    },

                    updatedMoviePerson: function (moviePersonsServices, moviePersonsSvc, vm, $stateParams) { //geting id from route
                        return moviePersonsSvc.updateMoviePerson($stateParams.id, vm.moviePerson); //calling services 
                    }, 

                    moviePersonProfile: function ($ocLazyLoad, moviePersonsServices, moviePerson) {
                        return $ocLazyLoad.load({ //loading controller
                            name: "updateMoviePerson",
                            files: [
                                "app/moviePersons/manage/updateMoviePerson.module.js"
                            ]
                        });
                    }

                }
            })

            .state('updateAuthor', {
                url: "/author/update/:id",
                controller: "authorManageCtrl",
                controllerAs: "vm",
                templateUrl: "app/authors/partials/updateAuthor.html",
                cache: false,
                resolve: {
                    loginRequired: loginRequired,
                    authorsServices: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "authorsServices",
                            files: [
                                "app/authors/authorsServices.module.js"
                            ]
                        });
                    },
                    author: function ($stateParams,authorsServices, authorsSvc) {
                        //TODO: fetch with authorsSvc
                        return null;
                    },
                    authors: function ($ocLazyLoad, authorsServices, author) {
                        return $ocLazyLoad.load({
                            name: "authors",
                            files: [
                                "app/authors/authors.module.js"
                            ]
                        });
                    }

                }
            })

            ;
    }

})();
