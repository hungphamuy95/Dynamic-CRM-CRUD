(function () {
    'use strict';

    angular.module('SampleApp').controller('UpdateAccountController', ['$scope','$routeParams','$http', UpdateAccount]);


    function UpdateAccount($scope, $routeParams, $http) {
        $scope.mesage = "hello";
        $scope.loadingreq = true;
        $scope.successreq = false;
        var self = this;
        self.guid = $routeParams.guid;
        $http.post('http://localhost:33359/api/Accout/' + $routeParams.id).then(function (respond) {
            $scope.loadingreq = false;
            $scope.default = respond.data;
            $scope.submit = function (_name, _str1, _phone, _str2, _numemp, _city, _description, _postcode) {
                $http({
                    method: "PUT",
                    url: "http://localhost:33359/api/UpdateAccount/" + respond.data.accountid,
                    data: { name: _name, description: _description, phone: _phone, numberemp: _numemp, str1: _str1, str2: _str2, city: _city, zipcode :_postcode}
                }).then(function (res) {
                    UpdateAccount();
                });
            }
        })
    }
})();
