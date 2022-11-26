(function () {
    'use strict';

    angular
        .module('app')
        .controller('DonViController', ['$scope', '$http', function ($scope, $http) {
            $scope.listObj = []
            $scope.obj = {
                Ten: '',
                LoaiDonVi: "1"
            }

            getListDonVi()

            function getListDonVi() {
                $http.get("/DonVi/Index")
                    .then(function (result) {
                        $scope.listObj = result.data
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.create = function () {
                $scope.obj.LoaiDonVi = Number($scope.obj.LoaiDonVi)
                $http.post("/DonVi/Create", $scope.obj)
                    .then(function (result) {
                        console.log(result.data)
                        $('#dialogNhomSp').modal('hide');
                        getListDonVi()
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }


        }]);

})();
