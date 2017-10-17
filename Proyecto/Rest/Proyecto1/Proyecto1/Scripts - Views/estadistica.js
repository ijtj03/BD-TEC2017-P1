var estadistica = angular.module('Estadistica', []);

estadistica.controller("AllController", function ($scope, $http, $location) {

    $http.get("http://localhost:64698/api/Empresa/GetIdEmpresa?id=" + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            $scope.EmpresaId = response.data;
            console.log($scope.cantidadesValue);
            $http.get("http://localhost:64698/api/Estadistica/GetAllProductosVendidosxCompania?id=" + $scope.EmpresaId)
                .then(function (response) {
                    $scope.cantidadesValue = response.data;
                    console.log($scope.cantidadesValue);
                });
        });


    $http.get("http://localhost:64698/api/Estadistica/GetAllProductosVendidos")
        .then(function (response) {
            $scope.AllValue = response.data;
            console.log($scope.cantidadesValue);
        });

    $http.get("http://localhost:64698/api/Estadistica/GetAllEmpresasxVentas")
        .then(function (response) {
            $scope.ventasValue = response.data;
            console.log($scope.ventasValue);
        });




});