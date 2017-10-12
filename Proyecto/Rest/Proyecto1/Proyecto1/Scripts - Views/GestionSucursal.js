var GestionSucursal = angular.module('GestionSucursal', []);

GestionSucursal.controller('GestionSucursalController', function ($scope, $http) {
    console.log("Gestion Doctor");
    $scope.IdEmpresa = $scope.IdEmpresa;
    $scope.nombre = $scope.nombre;
    $scope.IdAdministrador = $scope.IdAdministrador;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.direccion = $scope.direccion;


    $scope.agregar = function () {

        var sucursal = {
            IdEmpresa: $scope.IdEmpresa,
            Nombre: $scope.nombre,
            Administrador: $scope.IdAdministrador,
            Provincia: $scope.provincia,
            Canton: $scope.canton,
            Distrito: $scope.distrito,
            DescripcionDireccion: $scope.direccion,
        }

        console.log(sucursal);

        $http.post("http://localhost:64698/api/Sucursal/PostSucursal", sucursal)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/Administrador/GestionSucursales/GestionSucursal.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionSucursal.controller("EliminarController", function ($scope, $http, $location) {
    $scope.IdSucursal = $scope.IdSucursal;

    $scope.eliminar = function () {
        var IdSucursal = $scope.IdSucursal

        console.log(IdSucursal);

        $http.put("http://localhost:64698/api/Sucursal/PutLogicDelete", IdCedula).then(function successCallback(response) {
            console.log(response);
            window.location = "http://localhost:64698/Administrador/GestionSucursales/GestionSucursal.html";
        }, function errorCallback(response) {
            console.log(response);
        });
    }

});

GestionSucursal.controller('BuscarController', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $scope.cedula = $scope.cedula;


    $scope.buscar = function () {
        var IdCedula = $scope.cedula
        console.log(IdCedula);
        $http.Get("http://localhost:64698/api/Persona/GetPersona", IdCedula).then(function (response) {
            console.log("Geting");
            $scope.buscar = response.data;
            console.log("Geted");
        });
    }

});