(function () {
    'use strict';

    angular
        .module('app')
        .controller('NhomSanPhamController', ['$scope', '$http', function ($scope, $http) {
            $scope.listObj = []
            $scope.obj = {
                Ten: ''
            }

            getListNhomSanPham()

            function getListNhomSanPham() {
                $http.get("/NhomSanPham/Index").then(function (result) {
                    $scope.listObj = result.data
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.create = function () {
                $http.post("/NhomSanPham/Create", $scope.obj).then(function (result) {
                    console.log(result.data)
                    $('#dialogNhomSp').modal('hide');
                    getListNhomSanPham()
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

        }]);

})();
