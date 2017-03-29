(function () {
    'use strict';
    var controllerId = "accountController";
    //inject accountFactory
    angular.module('SampleApp').controller(controllerId, ['$scope', 'accountFactory', accoutController]);
    function accoutController($scope, accountFactory) {
        $scope.loadingimage = true;
        $scope.account = [];
        accountFactory.getAccount().then(
            function success(respond) {
                $scope.loadingimage = false;
                $scope.account = respond.data;
            }, function error(err) {
                console.log(err);
            }
        );
    }
})();
