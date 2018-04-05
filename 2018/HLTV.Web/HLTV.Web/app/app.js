///// <reference path="/Assets/admin/libs/angular/angular.js" />

//(function () {
//    angular.module('app',
//        ['ui.router'])
//        .config(config)
//        .config(configAuthentication)
//        //.run(['$rootScope', '$location', 'Auth', function ($rootScope, $location, Auth) {
//        //    console.log("XXX222");
//        //    $rootScope.$on('$routeChangeStart', function (event) {
//        //        console.log('$routeChangeStart')
//        //        if (!Auth.isLoggedIn()) {
//        //            console.log('DENY');
//        //            event.preventDefault();
//        //            $location.path('/login');
//        //        }
//        //        else {
//        //            console.log('ALLOW');
//        //            $location.path('/home');
//        //        }
//        //    });
//        //}])
//        //.factory('Auth', function () {
//        //     var user;

//        //     return {
//        //         setUser: function (aUser) {
//        //             user = aUser;
//        //         },
//        //         isLoggedIn: function () {
//        //             return (user) ? user : false;
//        //         }
//        //     }
//        // });

//    config.$inject = ['$stateProvider', '$urlRouterProvider'];
//    function config($stateProvider, $urlRouterProvider) {
//        $stateProvider
//             .state('base', {
//                 url: '',
//                 templateUrl: '/app/shared/views/baseView.html',
//                 abstract: true
//             }).state('login', {
//                 url: "/login",
//                 templateUrl: "/app/components/login/loginView.html",
//                 controller: "loginController"
//             })
//             .state('home', {
//                 url: "/admin",
//                 parent: 'base',
//                 templateUrl: "/app/components/home/homeView.html",
//                 controller: "homeController"
//             });
//        $urlRouterProvider.otherwise('/login');
//    }
//    function configAuthentication($httpProvider) {
//        $httpProvider.interceptors.push(function ($q, $location) {
//            return {
//                request: function (config) {

//                    return config;
//                },
//                requestError: function (rejection) {

//                    return $q.reject(rejection);
//                },
//                response: function (response) {
//                    if (response.status == "401") {
//                        $location.path('/login');
//                    }
//                    //the same response/modified/or a new one need to be returned.
//                    return response;
//                },
//                responseError: function (rejection) {

//                    if (rejection.status == "401") {
//                        $location.path('/login');
//                    }
//                    return $q.reject(rejection);
//                }
//            };
//        });
//    }
//})();

'use strict';

angular.module('BlurAdmin', [
  'ui.bootstrap',
  'ui.router',
  'ngTouch',
  'toastr',
  'ui.slimscroll',
  // 'angular-progress-button-styles',

  'BlurAdmin.theme',
  'BlurAdmin.pages',
  "BlurAdmin.common",
  "pascalprecht.translate"
])
.config(config)
.config(configAuthentication)


config.$inject = ['$stateProvider', '$urlRouterProvider'];
function config($stateProvider, $urlRouterProvider) {
    $stateProvider
         .state('base', {
             url: '',
             templateUrl: '/app/shared/views/baseView.html',
             abstract: true
         })
        .state('login', {
             
             url: "/login",
             templateUrl: "/app/components/login/loginView.html",
             controller: "loginController"
         })
         .state('home', {
             url: "/admin",
             parent: 'base',
             templateUrl: "/app/components/home/homeView.html",
             controller: "homeController"
         });
    $urlRouterProvider.otherwise('/login');
}
function configAuthentication($httpProvider) {
    $httpProvider.interceptors.push(function ($q, $location) {
        return {
            request: function (config) {

                return config;
            },
            requestError: function (rejection) {

                return $q.reject(rejection);
            },
            response: function (response) {
                if (response.status == "401") {
                    $location.path('/login');
                }
                //the same response/modified/or a new one need to be returned.
                return response;
            },
            responseError: function (rejection) {

                if (rejection.status == "401") {
                    $location.path('/login');
                }
                return $q.reject(rejection);
            }
        };
    });
}