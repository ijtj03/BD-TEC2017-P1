var GestionSucursal = angular.module('GestionSucursal', []);

GestionSucursal.controller('GestionSucursalController', function ($scope, $http) {
    console.log("Gestion Doctor");
    $http.get("http://localhost:64698/api/Persona/GetAllAdministrador")
        .then(function (response) {
            console.log("Getting");
            $scope.administradores = response.data;
            console.log("Getted");
            
        });

    $scope.nombre = $scope.nombre;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.direccion = $scope.direccion;


    $scope.agregar = function () {
        $http.get("http://localhost:64698/api/Persona/GetIdPersona?nombre=" + $scope.administrador)
            .then(function (response) {
                $scope.IDP = response.data;
                console.log($scope.IDP)
                $http.get("http://localhost:64698/api/Empresa/GetIdEmpresa?id=" + window.localStorage.getItem("idSucursal"))
                    .then(function (response) {
                        console.log(response.data);
                        $scope.IDE = response.data;
                        console.log($scope.IDE);
                        var sucursal = {
                            IdEmpresa: $scope.IDE,
                            Nombre: $scope.nombre,
                            Administrador: $scope.IDP,
                            Provincia: $scope.provincia,
                            Canton: $scope.canton,
                            Distrito: $scope.distrito,
                            DescripcionDireccion: $scope.direccion,
                        }

                        console.log(sucursal);
                        $http.post("http://localhost:64698/api/Sucursal/PostSucursal", sucursal)
                            .then(function successCallback(response) {
                                console.log(response);
                                $http.get("http://localhost:64698/api/Sucursal/GetLastSucursalId")
                                    .then(function (response) {
                                        $scope.IDS = response.data;
                                        var PXS = {
                                            IdCedula: $scope.IDP,
                                            SalarioHora: 3000,
                                            IdSucursal: $scope.IDS,
                                        }
                                        $http.post("http://localhost:64698/api/PersonaxSucursal/PostPersonaxSucursal", PXS)
                                            .then(function successCallback(response) {
                                                console.log(response);
                                                window.location = "http://localhost:64698/mywebsite/Administrador/GestionSucursales/GestionSucursales.html";
                                            }, function errorCallback(response) {
                                                console.log(response);
                                            });
                                    });
                            }, function errorCallback(response) {
                                console.log(response);
                            });
                    });
            });
            
    }

});

GestionSucursal.controller("EliminarController", function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Empresa/GetIdEmpresa?id=" + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            $scope.IDE = response.data;
            console.log($scope.IDE)
            $http.get("http://localhost:64698/api/Sucursal/GetAllNombreSucursales?id=" + $scope.IDE)
                .then(function (response) {
                    $scope.sucursales = response.data;
                    console.log($scope.sucursales)
                });
        });

    $scope.eliminar = function () {
        $http.get("http://localhost:64698/api/Sucursal/GetIdSucursal?nombre=" + $scope.sucursal)
            .then(function (response) {
                $scope.IDS = response.data;
                console.log($scope.IDS)
                $http.put("http://localhost:64698/api/Persona/EliminarEmpleadosxSucursal", $scope.IDS).then(function successCallback(response) {
                    console.log(response);
                    $http.put("http://localhost:64698/api/Sucursal/PutLogicDelete", $scope.IDS).then(function successCallback(response) {
                        console.log(response);
                        window.location = "http://localhost:64698/mywebsite/Administrador/GestionSucursales/GestionSucursales.html";
                    }, function errorCallback(response) {
                        console.log(response);
                    });
                }, function errorCallback(response) {
                    console.log(response);
                });
            });

        
    }

});

GestionSucursal.controller('ModificarController', function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Empresa/GetIdEmpresa?id=" + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            $scope.IDE = response.data;
            console.log($scope.IDE)
            $http.get("http://localhost:64698/api/Sucursal/GetAllNombreSucursales?id=" + $scope.IDE)
                .then(function (response) {
                    $scope.sucursales = response.data;
                    console.log($scope.sucursales)
                    $http.get("http://localhost:64698/api/Persona/GetAllAdministrador")
                        .then(function (response) {
                            console.log("Getting");
                            $scope.administradores = response.data;
                            console.log("Getted");

                        });
                });
        });

    $scope.buscar = function () {
        $http.get("http://localhost:64698/api/Sucursal/GetIdSucursal?nombre=" + $scope.sucursal)
            .then(function (response) {
                $scope.IDS = response.data;
                console.log($scope.IDS)
                $http.get("http://localhost:64698/api/Sucursal/GetSucursal?IdSucursal=" + $scope.IDS)
                    .then(function (response) {
                        $scope.Datos = response.data;

                    });
            });
    };
    $scope.modificar = function () {
        console.log("Modificar Sucursal");
        var pro = angular.element(document.getElementById("provincia")).val();
        var nom = angular.element(document.getElementById("nombre")).val();
        var cant = angular.element(document.getElementById("canton")).val();
        var dist = angular.element(document.getElementById("distrito")).val();
        var dire = angular.element(document.getElementById("direccion")).val();
        if (pro != '' && nom != '' && cant != '' &&
            dist != '' && dire != '') {

        $http.get("http://localhost:64698/api/Persona/GetIdPersona?nombre=" + $scope.administrador)
            .then(function (response) {
                $scope.IDP = response.data;
                var sucursal = {
                    IdEmpresa: $scope.IDE,
                    Nombre: nom,
                    Administrador: $scope.IDP,
                    Provincia: pro,
                    Canton: cant,
                    Distrito: dist,
                    DescripcionDireccion: dire,
                    IdSucursal: $scope.IDS,
                }
                console.log(sucursal)
                $http.post("http://localhost:64698/api/Sucursal/UpdateSucursal", sucursal)
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            });
        }
        else {
            alert("Rellene todos los campos");
        }
    };

});