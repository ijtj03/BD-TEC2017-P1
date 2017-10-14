var receta = angular.module('Recetas', []);
receta.controller("recetasController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Receta/GetRecetasId?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.misrecetas = response.data;
            console.log("Geted");
        });
    $scope.moveToId = function (idSucursal) {
        window.localStorage.setItem("idSucursal", idSucursal);
        window.location = "http://localhost:64698/mywebsite/WebCliente/medicinas.html";
    };
    $scope.addReceta = function () {
        window.location = "http://localhost:64698/mywebsite/WebCliente/addreceta.html";
    };
    
});