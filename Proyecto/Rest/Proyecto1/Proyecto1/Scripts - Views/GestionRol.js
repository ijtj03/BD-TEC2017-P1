var GestionRol = angular.module('GestionRol', []);

GestionRol.controller('GestionRolController', function ($scope, $http) {
    console.log("Gestion Rol");
    $scope.nombre = $scope.nombre;
    $scope.descripcion = $scope.descripcion;


    $scope.agregar = function () {

        var Rol = {
            Nombre: $scope.nombre,
            Descripcion: $scope.descripcion,
        }

        console.log(Rol);

        $http.post("http://localhost:64698/api/Rol/PostRol", Rol)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/Administrador/GestionRoles/GestionRoles.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionRol.controller("EliminarController", function ($scope, $http, $location) {
    $scope.IdRol = $scope.IdRol;

    $scope.eliminar = function () {
        var IdRol = $scope.IdRol;

        console.log(IdRol);

        $http.put("http://localhost:64698/api/Rol/PutLogicDelete", IdRol).then(function successCallback(response) {
            console.log(response);
            window.location = "http://localhost:64698/Administrador/GestionRoles/GestionRoles.html";
        }, function errorCallback(response) {
            console.log(response);
        });
    }

});

GestionRol.controller('ModificarController', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $scope.IdRol = $scope.IdRol;
    $scope.nombre = $scope.nombre;
    $scope.descripcion = $scope.descripcion;

    $scope.buscar = function () {
        var IdRol = $scope.IdRol;
        console.log(IdRol);
        $http.get('http://localhost:64698/api/Rol/GetRol?id=' + IdRol)
            .then(function successCallback(response) {
            console.log("Encontro el data");
            $scope.buscar = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });
    }

    $scope.modificar = function () {
        $http.put('http://localhost:64698/api/Rol/GetRol?id=' + IdRol)
            .then(function successCallback(response) {
                $scope.buscar = response.data;
                console.log("Encontro el data", $scope.buscar);
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});