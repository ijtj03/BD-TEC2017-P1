var GestionEmpleado = angular.module('GestionEmpleado', []);

GestionEmpleado.controller('AgregarController', function ($scope, $http) {
    $http.get("http://localhost:64698/api/Rol/GetAllRolN")
        .then(function (response) {
            console.log("Getting");
            $scope.roles = response.data;
            console.log("Getted");
        });
    $scope.cedula = $scope.cedula;
    $scope.nombre = $scope.nombre;
    $scope.apellido1 = $scope.apellido1;
    $scope.apellido2 = $scope.apellido2;
    $scope.telefono = $scope.telefono;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.fecha = $scope.fecha;
    $scope.salario = $scope.salario;


    $scope.agregar = function () {
        $http.get("http://localhost:64698/api/Rol/GetIdRol?nombre=" +$scope.rol)
            .then(function (response) {
                $scope.rolId = response.data;
                console.log($scope.rolId)
                var Empleado = {
                    IdCedula: $scope.cedula,
                    Nombre: $scope.nombre,
                    Apellido1: $scope.apellido1,
                    Apellido2: $scope.apellido2,
                    Telefono: $scope.telefono,
                    Contraseña: $scope.password,
                    Provincia: $scope.provincia,
                    Canton: $scope.canton,
                    Distrito: $scope.distrito,
                    DescripcionDireccion: $scope.direccion,
                    FechaNacimiento: $scope.fecha,
                }

                var PXR = {
                    IdCedula: $scope.cedula,
                    IdRol: $scope.rolId,
                }

                var PXS = {
                    IdCedula: $scope.cedula,
                    IdSucursal: 1,//Number(window.localStorage.getItem("idSucursal")),
                    SalarioHora: $scope.salario,
                }

                console.log(Empleado);
                console.log(PXR);
                console.log(PXS);


                $http.post("http://localhost:64698/api/Persona/PostPersona", Empleado)
                    .then(function successCallback(response) {
                        console.log("Se creo empleado")
                        $http.post("http://localhost:64698/api/PersonaxRol/PostPersonaxRol", PXR)
                            .then(function successCallback(response) {
                                console.log("Se creo personaxRol")
                                $http.post("http://localhost:64698/api/PersonaxSucursal/PostPersonaxSucursal", PXS)
                                    .then(function successCallback(response) {
                                        console.log("Se creo personaxSucursal")
                                        window.location = "http://localhost:64698/mywebsite/Administrador/GestionDoctores/GestionDoctores.html";
                                    }, function errorCallback(response) {
                                        console.log(response);
                                    });
                            }, function errorCallback(response) {
                                console.log(response);
                            })
                    }, function errorCallback(response) {
                        console.log(response);
                    })
            });
        
    }

});

GestionEmpleado.controller("EliminarController", function ($scope, $http, $location) {
    $scope.EID = $scope.EID;

    $scope.eliminar = function () {
        var IdEmpleado = $scope.EID;

        $http.put("http://localhost:64698/api/Persona/PutLogicDelete", IdEmpleado).then(function successCallback(response) {
            console.log(response);
            $http.put("http://localhost:64698/api/PersonaxRol/PutLogicDelete", IdEmpleado).then(function successCallback(response) {
                console.log(response);
                $http.put("http://localhost:64698/api/PersonaxSucursal/PutLogicDelete", IdEmpleado).then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionDoctores/GestionDoctores.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
            }, function errorCallback(response) {
                console.log(response);
            });
        }, function errorCallback(response) {
            console.log(response);
        });
    }

});

GestionEmpleado.controller('ModificarContoller', function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Rol/GetAllRolN")
        .then(function (response) {
            console.log("Getting");
            $scope.roles = response.data;
            console.log("Getted");
        });
    $scope.cedula = $scope.cedula;

    $scope.buscar = function () {
        var IdCedula = $scope.cedula
        $http.get("http://localhost:64698/api/Persona/GetPersona?id=" + IdCedula).then(function (response) {
            $scope.usuario = response.data;
            console.log(response.data);
            $http.get("http://localhost:64698/api/PersonaxRol/GetPersonaxRolId?cedula=" + IdCedula).then(function (response) {
                $scope.rolId = response.data;
                console.log(response.data);
                $http.get("http://localhost:64698/api/Rol/GetNombreRol?id=" + $scope.rolId).then(function (response) {
                    $scope.rol = response.data;
                    console.log($scope.rol);
                    $http.get("http://localhost:64698/api/PersonaxSucursal/GetPersonaxSucursal?id=" + IdCedula).then(function (response) {
                        $scope.salarioUsuario = response.data;
                        console.log(response.data);
                    });
                });
            });
        });
        
        
    }
    $scope.modificar = function () {
        console.log("Modificar Usuario");
        var tel = angular.element(document.getElementById("telefono")).val();
        var prov = angular.element(document.getElementById("provincia")).val();
        var can = angular.element(document.getElementById("canton")).val();
        var dis = angular.element(document.getElementById("distrito")).val();
        var dir = angular.element(document.getElementById("direccion")).val();
        var pass = angular.element(document.getElementById("password")).val();
        var sala = angular.element(document.getElementById("salario")).val();
        if (tel != '' && prov != '' && can != '' &&
            dis != '' && dir != '' && pass != '') {
            var editUsuario = {
                Contraseña: pass,
                Telefono: tel,
                DescripcionDireccion: dir,
                Provincia: prov,
                Canton: can,
                Distrito: dis,
                IdCedula: $scope.cedula,
            };
            var editSucursal = {
                IdCedula: $scope.cedula,
                SalarioHora: sala,
                IdSucrsal: Number(window.localStorage.getItem("idSucursal")),
            };
            console.log(editUsuario)
            console.log(editSucursal)
            $http.get("http://localhost:64698/api/Rol/GetIdRol?nombre=" + $scope.rol)
                .then(function (response) {
                    $scope.rolId = response.data;
                    console.log($scope.rolId)
                    var editRol = {
                        IdCedula: $scope.cedula,
                        IdRol: $scope.rolId , 
                    };
                    console.log(editRol)
                    $http.post("http://localhost:64698/api/Persona/UpdatePersona", editUsuario)
                        .then(function successCallback(response) {
                            console.log(response);
                            $http.post("http://localhost:64698/api/PersonaxRol/UpdatePersonaxRol", editRol)
                                .then(function successCallback(response) {
                                    console.log(response);
                                    $http.post("http://localhost:64698/api/PersonaxSucursal/UpdatePersonaxSucursal", editSucursal)
                                        .then(function successCallback(response) {
                                            console.log(response);
                                            window.location = "http://localhost:64698/mywebsite/Administrador/GestionClientes/GestionClientes.html";
                                        }, function errorCallback(response) {
                                            console.log(response);
                                        });
                                }, function errorCallback(response) {
                                    console.log(response);
                                });
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