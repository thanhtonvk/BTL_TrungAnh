var app = angular.module("Product", [])
app.controller("ProductController", function ($scope, $http) {
    debugger;
    var BASE_URL = "https://localhost:7070/api/"
    var Product;
    var flag = 0;
    $scope.getAllCategory = function () {
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
    $scope.getAllProduct = function () {
        $scope.getAllCategory()
        var keyword = document.getElementById('txtSearch').value;
        if (keyword === '') {
            keyword = 'null'
        }
        $http({
            method: 'GET',
            url: BASE_URL + 'Products/GetProductList',
            params: {
                keyword: keyword
            }
        }).then(function successCallback(response) {
            $scope.productList = response.data
            console.log(response.data)
        }, function errorCallback(response) {
            console.log(response)
        });
    }
    $scope.deleteProduct = function (item) {
        $http({
            method: "PUT",
            url: BASE_URL + 'Products/DeleteProduct',
            params: {
                id: item.id
            }
        }).then(function (res) {
            alert(res.data)
            $scope.getAllProduct('null')
        })
    }
    $scope.insertProduct = function () {
        var name = $scope._name;
        var idCategory = $scope._category;
        var image = $scope._image;
        var details = CKEDITOR.instances.details.getData()
        var description = CKEDITOR.instances.description.getData()
        var cost = $scope._cost;
        var isHot = $scope._isHost;
        var isSale = $scope._isSale;
        if (flag === 0) {
            var product = {
                "name": name,
                "category": "null",
                "idCategory": idCategory,
                "image": image,
                "details": details,
                "description": description,
                "cost": cost,
                "isHot": isHot,
                "isSale": isSale
            }
            $http({
                method: 'POST',
                url: BASE_URL + 'Products/PostProduct',
                data: product
            }).then(function successCallback(response) {
                console.log(response.data)
                $scope.getAllProduct('null')
            }, function errorCallback(response) {
                console.log(response)
            });
        } else {
            Product.name = $scope._name;
            Product.idCategory = $scope._category;
            Product.image = $scope._image;
            Product.details = CKEDITOR.instances.details.getData()
            Product.description = CKEDITOR.instances.details.getData()
            Product.cost = $scope._cost;
            Product.isHot = $scope._isHost;
            Product.isSale = $scope._isSale;
            Product.category = "null";
            $http({
                method: 'PUT',
                url: BASE_URL + 'Products/PutProduct',
                data: Product
            }).then(function successCallback(response) {
                $scope.getAllProduct('null')
            }, function errorCallback(response) {
                console.log(response)
                alert(response.message)
            });
            flag = 0
            document.getElementById('btnSave').value = "Thêm"
        }

        $scope._name = "";
        $scope._category = "";
        $scope._image = "";
        document.getElementById("details").value = "";
        document.getElementById("description").value = "";
        $scope._cost = "";
        $scope._isHost = "";
        $scope._isSale = "";
    }
    $scope.loadProduct = function (item) {
        Product = item;
        flag = 1;
        $scope._name = item.name
        $scope._category = item.idcategory;
        $scope._image = item.image;
        CKEDITOR.instances.details.setData(item.details)
        CKEDITOR.instances.description.setData(item.description)
        $scope._cost = item.cost;
        $scope._isHost = item.isHost;
        $scope._isSale = item.isSale;
        document.getElementById('btnSave').value = "Cập nhật"
    }
    $scope.getID = function (id){
        sessionStorage.setItem("productId",id)
        location.replace("../Image")
    }
})