(function () {
    'use strict';

    angular
        .module('app')
        .controller('ChiTietSanPhamController', ['$scope', '$http', '$location',
            function ($scope, $http, $location) {
                $scope.obj = {}
                getDetail()
                function getDetail() {
                    const idSanPham = $location.search().id

                    $http.get('SanPham/GetDetail?sanphamid=' + idSanPham)
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
