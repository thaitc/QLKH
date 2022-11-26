(function () {
    'use strict';

    angular
        .module('app')
        .controller('DonHangController', ['$scope', '$location', '$http',
            function ($scope, $location, $http) {
                $scope.listDonHang = []
                getListDonHang()
                function getListDonHang() {
                    $http.get("/HoaDon/Index")
                        .then(function (result) {
                            $scope.listDonHang = result.data
                        })
                        .catch(function (error) {
                            console.log(error)
                        })
                }
            }]);
})();
