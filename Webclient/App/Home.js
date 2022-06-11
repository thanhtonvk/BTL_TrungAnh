var app = angular.module("Home", [])
app.controller("HomeController", function($http, $scope) {
    debugger;
    var BASE_URL = "https://localhost:7070/api/"
    $scope.getHotProduct = function() {
        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductIsHot',
        }).then(function successCallback(response) {
            var list = response.data
            $scope.productHotList = list.slice(0, 4)
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.getSaleProduct = function() {
        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductIsHot',
        }).then(function successCallback(response) {
            var list = response.data
            $scope.productSaleList = list.slice(0, 4)
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }

    $scope.getAllCategory = function() {

        var keyword = 'null'

        $http({
            method: 'GET',
            url: BASE_URL + 'Category/GetCategoryList',
            params: {
                keyword: keyword
            }
        }).then(function successCallback(response) {
            $scope.categoryList = response.data
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.getAllProduct = function(index) {

        var keyword = 'null'

        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductList',
            params: {
                keyword: keyword
            }
        }).then(function successCallback(response) {
            var list = response.data

            $scope.productList = list.slice(0, 8)


            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.getIdProduct = function(id) {
        sessionStorage.clear()
        sessionStorage.setItem("productID", id)
        location.href = "../Details.html"
    }
    $scope.loadProduct = function() {
        var id = sessionStorage.getItem("productID")
        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductById',
            params: {
                id: id
            }
        }).then(function successCallback(response) {
            $scope.product = response.data
            document.getElementById("details").innerHTML = $scope.product.details
            document.getElementById("description").innerHTML = $scope.product.description
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
        $scope.getAllImage()
        sessionStorage.clear()
    }
    $scope.getAllImage = function() {
        var productId = sessionStorage.getItem("productID")
        $http({
            method: "GET",
            url: BASE_URL + "ImageProduct/GetListImage",
            params: {
                "productID": productId
            }
        }).then(function(res) {
            $scope.imageList = res.data
        })
    }
    $scope.getIdCategory = function(id) {
        sessionStorage.setItem("idBrand", id)
        location.href = "../ProductByBrand.html"
    }
    $scope.getProductByBrand = function() {
        var idBrand = sessionStorage.getItem("idBrand")
        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductByCategory',
            params: {
                idCategory: idBrand
            }
        }).then(function successCallback(response) {

            $scope.productList = response.data
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.login = function() {
        var user = $scope._username;
        var pass = $scope._password;
        $http({
            method: 'POST',
            url: BASE_URL + 'Account/Login',
            params: {
                username: user,
                password: pass
            }
        }).then(function(res) {
            console.log(res.data)
            if (res.data.userName === user) {
                location.href = '../Admin/Product/Index.html'
            } else {
                alert("Tài khoản hoặc mật khẩu không chính xác ")
            }
        })
    }
    $scope.register = function() {
        var user = $scope._username1;
        var pass = $scope._password1;
        $http({
            method: 'POST',
            url: BASE_URL + 'Account/Register',
            params: {
                username: user,
                password: pass
            }
        }).then(function(res) {
            console.log(res.data)
            alert("Đăng ký thành công")
        })
    }
    $scope.addCart = function(item) {
        var jsonString = localStorage.getItem("gioHang")
        var list = JSON.parse(jsonString)
        var cart = {
            "id": Math.floor(Math.random() * 1000),
            "name": item.name,
            "image": item.image,
            "quantity": 1,
            "cost": item.cost
        }
        if (list == null) {
            list = [];
            list.push(cart)
        } else {
            list.push(cart)
        }
        localStorage.setItem('gioHang', JSON.stringify(list))
        alert('Thêm giỏ hàng thành công')
    }
    $scope.getCartList = function() {
        var jsonString = localStorage.getItem("gioHang")
        $scope.listCart = JSON.parse(jsonString)
        var tong = 0
        for (var i in $scope.listCart) {
            tong = tong + $scope.listCart[i].cost
        }
    }
    $scope.deleteCart = function(index) {
        var jsonString = localStorage.getItem("gioHang")
        $scope.listCart = JSON.parse(jsonString)
        delete $scope.listCart[index]
        localStorage.setItem('gioHang', JSON.stringify($scope.listCart))
        alert("Thành công")
        location.reload()
    }
    $scope.deleteAllCart = function() {
        localStorage.removeItem("gioHang")
        location.href = "../index.html"
    }


})