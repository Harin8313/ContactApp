
var app = angular
    .module('ContactApp', ['ngRoute', 'ngMask']);

app.config(function ($routeProvider, $locationProvider) {

    $routeProvider
        .when('/', {
            templateUrl: 'app/List.html',
            controller: 'ContactListController',
            resolve: {
                responseList: ['dataFactory', function (dataFactory) {
                    return dataFactory.getContacts();
                 }]
            }
        })
        .when('/edit/:Id', {
            templateUrl: 'app/Detail.html',
            controller: 'EditContactController'
        })
        .when('/new', {
            templateUrl: 'app/Detail.html',
            controller: 'NewContactController'
        })
        .otherwise({
            redirectTo: '/'
        });

    $locationProvider.html5Mode(true);

});




