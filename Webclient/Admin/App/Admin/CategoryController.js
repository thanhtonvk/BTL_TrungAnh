var app = angular.module("Category", [])
app.controller("CategoryController", function ($scope, $http) {
    debugger;
    var BASE_URL = "https://localhost:7070/api/"
    var Category;
    var flag = 0;
    $scope.getAllCategory = function () {
        var keyword = document.getElementById('txtSearch').value;
        if (keyword === '') {
            keyword = 'null'
        }
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
    $scope.deleteCategory = function (item) {
       
        $http({
            method: "PUT",
            url: BASE_URL + 'Category/DeleteCategory',
            params: {
                id: item.id
            }
        }).then(function (res) {
            alert(res.data)
            $scope.getAllCategory('null')
        })
    }
    $scope.insertCategory = function () {
        var name = $scope._name;
        var image = $scope._image;
        if (flag === 0) {
            var category = {
                "Name": name,
                "Image": image
            }
            $http({
                method: 'POST',
                url: BASE_URL + 'Category/PostCategory',
                data: category
            }).then(function successCallback(response) {
                console.log(response.data)
                $scope.getAllCategory('null')
            }, function errorCallback(response) {
                console.log(response)
            });
        } else {
            Category.name = $scope._name;
            Category.image = $scope._image;
            $http({
                method: 'POST',
                url: BASE_URL + 'Category/PutCategory',
                data: Category
            }).then(function successCallback(response) {
                $scope.getAllCategory('null')
            }, function errorCallback(response) {
                console.log(response)
            });
            flag = 0
            document.getElementById('btnSave').value = "Thêm"
        }

        $scope._name = ""
        $scope._image = ""
    }
    $scope.loadCategory = function (item) {
        Category = item;
        flag = 1;
        $scope._name = item.name;
        $scope._image = item.image;
        document.getElementById('btnSave').value = "Cập nhật"
    }
})