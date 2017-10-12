var mainsucursal = angular.module('MainSucursal', []);

mainsucursal.controller('MainSucursalController', function ($scope, $http) {
    console.log(window.localStorage.getItem("id"));
    $http.get('http://localhost:64698/api/Persona/GetSucursalPersona?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log(response.data);
            window.localStorage.setItem("idsucursal", response.data);


            $http.get('http://localhost:64698/api/Sucursal/GetSucursal?IdSucursal=' + window.localStorage.getItem("idsucursal"))
                .then(function (response) {
                    $scope.sucursal = response.data;
                    console.log(response.data);
                });
        });

});