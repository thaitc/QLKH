(function () {
    'use strict';

    angular
        .module('app')
        .controller('ThuocTinhSanPhamController', ['$scope', '$http', function ($scope, $http) {
            $scope.listThuocTinh = []
            $scope.obj = {
                Ten: ''
            }

            $scope.objUpdate = {}

            getListThuocTinh()

            function getListThuocTinh() {
                $http.get("/ThuocTinhSanPham/Index").then(function (result) {
                    $scope.listThuocTinh = result.data
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.create = function () {
                $http.post("/ThuocTinhSanPham/Create", $scope.obj).then(function (result) {
                    console.log(result.data)
                    $('#dialogThuocTinh').modal('hide');
                    getListThuocTinh()
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.openDialogUpdate = function (id) {
                $http.get("/ThuocTinhSanPham/GetDetail?IdNhomSp=" + id).then(function (result) {
                    $scope.objUpdate = result.data
                    $('#dialogUpdateThuocTinh').modal('show');
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }
        }]);
})();
