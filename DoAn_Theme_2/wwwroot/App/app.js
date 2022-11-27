(function () {
    'use strict';

    angular.module('app', ['ngRoute']).config(['$routeProvider', function ($routeProvider) {
        $routeProvider
            .when("/", {
                controller: 'TongQuanController',
                templateUrl: "/App/Templates/TongQuan.html"
            }) 
            .when("/SanPham", {
                controller: 'SanPhamController',
                templateUrl: "/App/Templates/SanPham.html"
            }) 
            .when("/Bill", {
                controller: 'DonHangController',
                templateUrl: "/App/Templates/HoaDon.html"
            }) 
            .when("/Customer", {
                //controller: 'SanPhamController',
                templateUrl: "/App/Templates/KhachHang.html"
            }) 
            .when("/User", {
                //controller: 'SanPhamController',
                templateUrl: "/App/Templates/TaiKhoan.html"
            }) 
            .when("/Permission", {
               // controller: 'SanPhamController',
                templateUrl: "/App/Templates/PhanQuyen.html"
            }) 
            .when("/Report", {
                // controller: 'SanPhamController',
                templateUrl: "/App/Templates/BaoCao.html"
            }) 
            .when("/PropertyProduct", {
                 controller: 'ThuocTinhSanPhamController',
                templateUrl: "/App/Templates/ThuocTinhSanPham.html"
            }) 
            .when("/Category", {
                 controller: 'NhomSanPhamController',
                templateUrl: "/App/Templates/NhomSanPham.html"
            }) 
            .when("/CreateBill", {
                controller: 'TaoDonHangController',
                templateUrl: "/App/Templates/TaoDonHang.html"
            }) 
            .when("/Unit", {
                controller: 'DonViController',
                templateUrl: "/App/Templates/DonVi.html"
            }) 
            .when("/DetailBill", {
                controller: 'ChiTietDonHangController',
                templateUrl: "/App/Templates/ChiTietDonHang.html"
            }) 
            .when("/DetailProduct", {
                controller: 'ChiTietSanPhamController',
                templateUrl: "/App/Templates/ChiTietSanPham.html"
            }) 
            .when("/UpdateProduct", {
                controller: 'SuaSanPhamController',
                templateUrl: "/App/Templates/SuaSanPham.html"
            }) 
    }]);
})();