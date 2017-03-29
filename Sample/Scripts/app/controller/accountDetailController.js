(function () {
    'use strict';
   
    angular.module('SampleApp').controller('accountDetailController', ['$scope', accountDetail]);
    function accountDetail($scope) {
        $scope.message = "hi there";
    }
})();
