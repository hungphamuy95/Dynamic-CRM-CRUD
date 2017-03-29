(function () {
    'use strict';

    angular
        .module('SampleApp')
        .factory('createAccountFactory',['$http', createAccountFactory]);


    function createAccountFactory($http) {
        var service = {
            postData: postData
        };

        return service;

        function postData() {

        }
    }
})();