var GestionEmpleado = angular.module('GestionEmpleado', []);

GestionEmpleado.controller('AgregarController', function ($scope, $http) {
    $scope.cedula = $scope.cedula;
    $scope.nombre = $scope.nombre;
    $scope.apellido1 = $scope.apellido1;
    $scope.apellido2 = $scope.apellido2;
    $scope.telefono = $scope.telefono;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.fecha = $scope.fecha;
    $scope.IdRol = $scope.IdRol;
    $scope.salario = $scope.salario;


    $scope.agregar = function () {

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
            IdRol: $scope.IdRol,
        }

        var PXS = {
            IdCedula: $scope.cedula,
            IdSucursal: Number(window.localStorage.getItem("idSucursal")),
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

GestionUsuario.controller('ModificarContoller', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $scope.cedula = $scope.cedula;
    $scope.buscar = function () {
        var IdCedula = $scope.cedula
        $http.get("http://localhost:64698/api/Persona/GetPersona?id=" + IdCedula).then(function (response) {
            console.log("Geting");
            $scope.buscar = response.data;
            console.log(response.data);
            console.log("Geted");
        });
        $http.get("http://localhost:64698/api/PersonaxRol/GetPersonaxRol?id=" + IdCedula).then(function (response) {
            console.log("Geting");
            $scope.buscarRol = response.data;
            console.log(response.data);
            console.log("Geted");
        });
        $http.get("http://localhost:64698/api/PersonaxSucursal/GetPersonaxSucursal?id=" + IdCedula).then(function (response) {
            console.log("Geting");
            $scope.buscarSucursal = response.data;
            console.log(response.data);
            console.log("Geted");
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
            $http.post("http://localhost:64698/api/Persona/UpdatePersona", editUsuario)
                .then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionClientes/GestionClientes.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
        else {
            alert("Rellene todos los campos");
        }

    };

});