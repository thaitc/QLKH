(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChiTietDonHangController', ['$scope', '$http', '$location',
            function ($scope, $http, $location) {
                $scope.obj = {}
                getDetail()
                function getDetail() {
                    const idDonHang = $location.search().id

                    $http.get('HoaDon/GetDetail?idhoadon=' + idDonHang)
                        .then(function (result) {
                            $scope.obj = result.data
                            console.log($scope.obj)
                        })
                        .catch(function (error) {

                        })
                }
            }
        ]);
})();
