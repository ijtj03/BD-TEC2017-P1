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
                window.location = "http://localhost:64698/mywebsite/Administrador/GestionRoles/GestionRoles.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionRol.controller("EliminarController", function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Rol/GetAllRolN")
        .then(function (response) {
            console.log("Getting");
            $scope.roles = response.data;
            console.log("Getted");
        });

    $scope.eliminar = function () {
        $http.get("http://localhost:64698/api/Rol/GetIdRol?nombre=" + $scope.rol)
            .then(function (response) {
                $scope.rolId = response.data;
                console.log($scope.rolId)
                $http.put("http://localhost:64698/api/Rol/PutLogicDelete", $scope.rolId).then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionRoles/GestionRoles.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
            });
    }

});

GestionRol.controller('ModificarController', function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Rol/GetAllRolN")
        .then(function (response) {
            console.log("Getting");
            $scope.roles = response.data;
            console.log("Getted");
        });

    $scope.buscar = function () {
        $http.get("http://localhost:64698/api/Rol/GetIdRol?nombre=" + $scope.rol)
            .then(function (response) {
                $scope.rolId = response.data;
                console.log($scope.rolId)
                $http.get('http://localhost:64698/api/Rol/GetRol?id=' + $scope.rolId)
                    .then(function successCallback(response) {
                        $scope.buscar = response.data;
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            });
        
    }

    $scope.modificar = function () {
        console.log("Modificar Usuario");
        var nom = angular.element(document.getElementById("nombre")).val();
        var desc = angular.element(document.getElementById("descripcion")).val();
        if (nom != '' && desc != '' ) {
            var editRol = {
                Nombre: nom,
                Descripcion: desc,
                IdRol: $scope.rolId,
            };
            $http.post("http://localhost:64698/api/Rol/UpdateRol", editRol)
                .then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionRoles/GestionRoles.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
        else {
            alert("Rellene todos los campos");
        }
    };

});