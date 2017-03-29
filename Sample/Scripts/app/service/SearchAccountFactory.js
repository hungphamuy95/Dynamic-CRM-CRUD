(function () {
    'use strict';

    angular
        .module('SampleApp')
        .factory('SearchAccountFactory', ['$http',SearchAccountFactory]);

    function SearchAccountFactory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData(selectedAttr, selectedName, value) {
            return $http({
                method: "POST",
                url: "",
                data:{selectedAttr, selectedName, value}
            });
        }
    }
})();