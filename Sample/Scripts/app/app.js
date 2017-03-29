(function () {
    'use strict';

    var app= angular.module('SampleApp', [
        // Angular modules 
        'ngRoute'

        // Custom modules 

        // 3rd Party Modules
        
    ]);
    app.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/account', {
            templateUrl: 'Scripts/app/template/accountlist.html',
            controller: 'accountController'
        }).
        when('/accountdetail', {
            templateUrl: 'Scripts/app/template/acountdetail.html',
            controller: 'accountDetailController'
        }).
        when('/updateaccount/:id', {
            templateUrl: 'Scripts/app/template/UpdateAccount.html',
            controller: 'UpdateAccountController'
        }).
        when('/searchaccount', {
            templateUrl: 'Scripts/app/template/SearchAccount.html',
            controller: 'SearchAccountController'
        });
        }
    ]);
})();