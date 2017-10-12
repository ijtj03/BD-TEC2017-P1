var register = angular.module('Register', []);

register.controller('registerController', function ($scope, $http) {
    console.log("Register");
    $scope.cedula = $scope.cedula;
    $scope.nombre = $scope.nombre;
    $scope.apellido1 = $scope.apellido1;
    $scope.apellido2 = $scope.apellido2;
    $scope.telefono = $scope.telefono;
    $scope.provincia = $scope.provincia;
    $scope.canton = $scope.canton;
    $scope.distrito = $scope.distrito;
    $scope.fecha = $scope.fecha;
    
    $scope.register = function () {
        console.log("Hola");

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
                window.location = "http://localhost:64698/mywebsite/login.html";
            }, function errorCallback(response) {
                console.log(response);
            });
   }
});