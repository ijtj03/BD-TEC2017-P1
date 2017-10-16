var GestionUsuario = angular.module('GestionUsuario', []);

GestionUsuario.controller('GestionUsuarioController', function ($scope, $http) {
    console.log("Gestion Usurario");
    $scope.cedula = $scope.cedula;
    $scope.nombre = $scope.nombre;
    $scope.apellido1 = $scope.apellido1;
    $scope.apellido2 = $scope.apellido2;
    $scope.telefono = $scope.telefono;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.fecha = $scope.fecha;
    console.log("Termino");


    $scope.agregar = function () {
        console.log("ENTRO AQUI");

        var usuario = {
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

        console.log(usuario);

        $http.post("http://localhost:64698/api/Persona/PostPersona", usuario)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/mywebsite/Administrador/GestionClientes/GestionClientes.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionUsuario.controller("EliminarController", function ($scope, $http, $location) {
    console.log("HOLA");
    $scope.cedula = $scope.cedula;
    $scope.h = "HOLA";//window.localStorage.getItem("id");
    console.log(window.localStorage.getItem("id"));

    $scope.eliminar = function () {
        console.log("ENTRO AQUI");
        var IdCedula = $scope.cedula

        console.log(IdCedula);

        $http.put("http://localhost:64698/api/Persona/PutLogicDelete", IdCedula).then(function successCallback(response) {
            console.log(response);
            window.location = "http://localhost:64698/mywebsite/Administrador/GestionClientes/GestionClientes.html";
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