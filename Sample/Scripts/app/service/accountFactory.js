(function () {
    'use strict';
    var serviceId = 'accountFactory';
    angular
        .module('SampleApp').factory(serviceId,['$http', accountFactory]);
    function accountFactory($http) {
        function getAccount() {
            return $http.get('http://localhost:33359/api/GetAll');
        }
        var service = { getAccount: getAccount };
        return service;
    }
})();