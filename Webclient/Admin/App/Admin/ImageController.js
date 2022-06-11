var app = angular.module("Image",[])
app.controller("ImageController",function ($scope,$http){
    debugger
    var flag = 0
    var Image;
    var BASE_URL = "https://localhost:7070/api/"
    $scope.getAllImage = function () {
        var productId = sessionStorage.getItem("productId")
        $http({
            method: "GET",
            url: BASE_URL + "ImageProduct/GetListImage",
            params: {
                "productID": productId
            }
        }).then(function (res) {
            $scope.imageList = res.data
        })
    }
    $scope.insertImage = function (){
        var productId = sessionStorage.getItem("productId")
        var link = $scope._image;
        if(flag ===0){
            var imageProduct = {
                "id": 0,
                "productID": productId,
                "image": link,
                "isActive":1
            }

            $http({
                method: "POST",
                url: BASE_URL+"ImageProduct/Add",
                data:imageProduct
            }).then(function (){
                $scope.getAllImage()
            })
        }else{
            Image.image = $scope._image
            $http({
                method:"PUT",
                url:BASE_URL+"ImageProduct/Update",
                data:Image
            }).then(function (){
                $scope.getAllImage()
            })
        }
        $scope._image = ""
       
    }
    $scope.loadImage = function (item){
        Image = item;
        $scope._image = item.image
        flag = 1
        document.getElementById("btnSave").value= "Cập nhật"
       
    }
    $scope.deleteImage = function (item){
        $http({
            method:"PUT",
            url: BASE_URL+"ImageProduct/Delete",
            params:{
                id:item.id
            }
        }).then(function (res){
            $scope.getAllImage()
            alert(res.data)
        })
    }
})