(function () {
    'use strict';

    angular
        .module('app')
        .controller('SanPhamController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
            $scope.obj = {}

            getList()
            getListNhomSanPham()
            getListThuocTinh()

            $scope.listProduct = []
            $scope.previewData = []
            $scope.listFile = []
            $scope.listPropertyProduct = []
            $scope.listProperty = []
            $scope.listCategoryProduct = []

            function getList() {
                $http.get("/SanPham/Index").then(function (result) {
                    $scope.listProduct = result.data
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            function getListNhomSanPham() {
                $http.get("/NhomSanPham/Index").then(function (result) {
                    $scope.listCategoryProduct = result.data
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            function getListThuocTinh() {
                $http.get("/ThuocTinhSanPham/Index").then(function (result) {
                    $scope.listProperty = result.data
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.create = function () {
                $scope.obj.IdNhomHang = Number($scope.obj.IdNhomHang)

                const param = {
                    sanPham: $scope.obj,
                    thuocTinhs: $scope.listPropertyProduct.map(x => ({
                        IdThuocTinh: Number(x.IdThuocTinh),
                        GiaTri: x.GiaTri
                    }))
                }

                console.log("param hàm create sản phẩm:", param)

                $http.post("/SanPham/Create", param).then(function (result) {
                    console.log(result.data)
                    let formData = new FormData()

                    for (var index in $scope.listFile) 
                        formData.append("files", $scope.listFile[index])

                    formData.append("IdSanPham", result.data)

                    var config = { headers: { 'Content-Type': undefined } };
                    $http.post("/TaiLieuSanPham/UploadTaiLieu", formData, config)
                        .then(function (result) {
                            console.log(result)
                        })
                        .catch(function (error) {
                            console.log(error)
                        })
                    
                    $('#exampleModalLong').modal('toggle');
                    getList()
                })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.previewFile = function (input) {
                //const index = input.attributes['data-index'].value;
                if (input.files) {
                    var filesAmount = input.files.length;

                    for (let i = 0; i < filesAmount; i++) {
                        $scope.listFile.push(input.files[i]);
                        const fileName = input.files[i].name
                        var reader = new FileReader();

                        let isImgFile = input.files[i] && input.files[i]['type'].split('/')[0] === 'image';

                        reader.onload = function (event) {
                            $scope.$apply(function () {
                                let srcFile = event.target.result
                                if (!isImgFile)
                                    srcFile = "/img/iconFile.png"
                                $scope.previewData.push({ name: fileName, src: event.target.result, id: '', icon: srcFile })
                            });
                            // $($.parseHTML('<img>')).attr({ src: event.target.result, width: '80px', 'margin-right': '10px' }).appendTo(placeToInsertImagePreview);
                        }
                        reader.readAsDataURL(input.files[i]);
                    }
                }
            }

            $scope.addProperty = function () {
                $scope.listPropertyProduct.push({
                    IdThuocTinh: 0,
                    GiaTri: ''
                })
            }

            $scope.removeFile = function (index) {
                $scope.previewData = $scope.previewData.splice(index, 1)
                $scope.listFile = $scope.listFile.splice(index, 1)
            }

            $scope.removeProperty = function (index) {
               $scope.listPropertyProduct.splice(index, 1)
            }
        }]);

})();
