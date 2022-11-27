(function () {
    'use strict';

    angular
        .module('app')
        .controller('SuaSanPhamController', ['$scope', '$http', '$location',
            function ($scope, $http, $location) {
                $scope.obj = {}
                $scope.listProperty = []
                $scope.listCategoryProduct = []

                getDetail()
                getListThuocTinh()
                getListNhomSanPham()

                function getDetail() {
                    const idSanPham = $location.search().id

                    $http.get('SanPham/GetDetail?sanphamid=' + idSanPham)
                        .then(function (result) {
                            $scope.obj = result.data
                            $scope.obj.idNhomHang = $scope.obj.idNhomHang.toString()
                            for (var i of $scope.obj.listThuocTinh) {
                                i.id = i.id.toString()
                             }
                            console.log($scope.obj)
                        })
                        .catch(function (error) {

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

                function getListNhomSanPham() {
                    $http.get("/NhomSanPham/Index").then(function (result) {
                        $scope.listCategoryProduct = result.data
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
                    $scope.obj.listThuocTinh.push({
                        id: '',
                        giaTri: ''
                    })
                }

                $scope.removeFile = function (index) {
                    $scope.previewData = $scope.previewData.splice(index, 1)
                    $scope.listFile = $scope.listFile.splice(index, 1)
                }

                $scope.removeProperty = function (index) {
                    if (index !== -1) {
                        //var a = $scope.obj.listThuocTinh.splice(index, 1)
                       $scope.obj.listThuocTinh.splice(index, 1)
                    }
                }

                $scope.save = function () {
                   
                    const param = {
                        sanPham: {
                            Id: $scope.obj.id,
                            Ten: $scope.obj.ten,
                            GiaBan: Number($scope.obj.giaBan),
                            GiaVon: Number($scope.obj.giaVon),
                            TonKho: Number($scope.obj.tonKho),
                            IdNhomHang: Number($scope.obj.idNhomHang)
                        },
                        thuocTinhs: $scope.obj.listThuocTinh.map(x => ({
                            IdThuocTinh: Number(x.id),
                            GiaTri: x.giaTri
                        }))
                    }

                    console.log("param hàm create sản phẩm:", param)

                    $http.post("/SanPham/UpdateSanPham", param).then(function (result) {
                        console.log(result.data)
                        alert('Cập nhật sản phẩm thành công')
                        //let formData = new FormData()

                        //for (var index in $scope.listFile)
                        //    formData.append("files", $scope.listFile[index])

                        //formData.append("IdSanPham", result.data)

                       // var config = { headers: { 'Content-Type': undefined } };
                        //$http.post("/TaiLieuSanPham/UploadTaiLieu", formData, config)
                        //    .then(function (result) {
                        //        console.log(result)
                        //    })
                        //    .catch(function (error) {
                        //        console.log(error)
                        //    })

                        
                    })
                        .catch(function (error) {
                            console.log(error)
                        })
                }
            }
        ]);
})();
