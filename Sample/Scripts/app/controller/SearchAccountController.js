(function () {
    'use strict';

    angular.module('SampleApp').controller('SearchAccountController', ["$scope", "$http", searchAccount]);
    function searchAccount($scope,$https) {
        $scope.searchresult = [];
        $scope.FuncChange = function () {
            $scope.filter = function (selectedAttr, value) {
                $http({
                    method: "GET",
                    url: "http://localhost:33359/api/SearchByDetail?attr=" + selectedAttr + "&value=" + value,
                }).then(function (respond) {
                    $scope.filterres = respond.data.name;
                });
            }
        };
    }
})();
