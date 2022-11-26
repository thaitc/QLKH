(function () {
    'use strict';

    angular
        .module('app')
        .controller('TaoDonHangController', ['$scope', '$http', function ($scope, $http) {
            $scope.khachHang = {}
            $scope.sanPhamsDrop = []
            $scope.listKHSearch = []
            $scope.objKHSearch = {
                Ten: '',
                Email: '',
                SoDienThoai: ''
            }
            $scope.active = false
            $scope.listDonVi = []
            $scope.isNewCustomer = false
            $scope.chiTietDonHangs = [{
                id: null,
                ten: '',
                path: '',
                soLuong: null,
                giaBan: null,
                active: false,
                thanhTien: null
            }]

            $scope.AddProduct = function () {
                $scope.chiTietDonHangs.push({
                    id: null,
                    ten: '',
                    path: '',
                    soLuong: null,
                    giaBan: null,
                    active: false,
                    thanhTien: null
                })
            }

            $scope.changeProduct = function (item, index) {
                Object.assign($scope.chiTietDonHangs[index], item)
                $scope.changeTrietKhau(index)
            }

            $scope.showDropSP = function (index) {
                $scope.chiTietDonHangs[index].active = !$scope.chiTietDonHangs[index].active
            }

            $scope.createCustomer = function () {
                $http.post("/KhachHang/Create", $scope.khachHang)
                    .then(function (result) {
                        console.log(result.data)
                        $scope.khachHang.id = result.data
                        alert('Thêm khách hàng thành công')
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            getListSanPhamDrop()
            getListDonVi()
            function getListSanPhamDrop() {
                $http.get("/SanPham/GetSanPhamDropList")
                    .then(function (result) {
                        console.log(result.data)
                        $scope.sanPhamsDrop = result.data
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            function getListDonVi() {
                $http.get("/DonVi/Index")
                    .then(function (result) {
                        $scope.listDonVi = result.data
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.changeTrietKhau = function (index) {
                var donHang = $scope.chiTietDonHangs[index]
                donHang.thanhTien = donHang.giaBan * donHang.soLuong

                if (!donHang.trietKhau || !donHang.donViTrietKhau)
                     donHang.thanhTien

                // Triết khấu theo %
                if (donHang.donViTrietKhau == "1")
                     donHang.thanhTien -= (donHang.giaBan * (donHang.trietKhau / 100))

                // Triết khấu theo số tiền cố định
                if (donHang.donViTrietKhau == "2")
                     donHang.thanhTien -= donHang.trietKhau
            }

            $scope.createBill = function () {
                console.log($scope.chiTietDonHangs)
                const chiTietDonHang = $scope.chiTietDonHangs.map(x => ({
                    IdSanPham: x.id,
                    SoLuong: x.soLuong,
                    DonGia: x.giaBan,
                    IdDonViTrietKhau: Number(x.donViTrietKhau),
                    TrietKhau: x.trietKhau,
                    ThanhTien: x.thanhTien
                }))

                const param = {
                    IdKhachHang: $scope.khachHang.id,
                    ChiTietDonHangs: chiTietDonHang
                }

                $http.post("/HoaDon/Create", param)
                    .then(function (result) {
                        console.log(result.data)
                        alert('Tạo đơn hàng thành công')
                    })
                    .catch(function (error) {
                        console.log(error)
                    })
            }

            $scope.getCustomerByCode = function () {
                $http.get('KhachHang/GetByCode?makhachhang=' + $scope.khachHang.Ma)
                    .then(function (result) {
                        $scope.khachHang.id = result.data.id
                        $scope.khachHang.Ten = result.data.ten
                        $scope.khachHang.SoDienThoai = result.data.soDienThoai
                        $scope.khachHang.Email = result.data.email
                        $scope.khachHang.NgaySinh = new Date(result.data.ngaySinh)
                        $scope.khachHang.DiaChi = result.data.diaChi
                    })
                    .catch(function (error) {

                    })
            }

            $scope.filterCustomer = function () {
                $http.post('KhachHang/Index', $scope.objKHSearch)
                    .then(function (result) {
                        $scope.listKHSearch = result.data
                    })
                    .catch(function (error) {

                    })
            }
        }]);
})();
