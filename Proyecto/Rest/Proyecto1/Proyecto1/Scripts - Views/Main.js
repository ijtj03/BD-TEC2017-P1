var main = angular.module('Main', []);

main.controller("mainController", function mainController($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Persona/GetPersona?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.perfil = response.data;
            console.log("Geted");
        });

    $scope.goToEdit = function () {
        console.log("Editar perfil");
        window.location = "http://localhost:64698/mywebsite/WebCliente/editperfil.html";
    };
    $scope.addEnf = function () {
        window.location = "http://localhost:64698/mywebsite/WebCliente/addenf.html";
    };
});

main.controller("misEnfController", function misEnfController($scope, $http) {
    $http.get('http://localhost:64698/api/EnfermedadxPersona/GetMisEnfermedades?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.misenfermedades = response.data;
            console.log("Geted");
        });
    $scope.eliminarEnf = function (idEnf,fEnf) {
        console.log("estoy en la funcion");
        var eliminarEnfermedad = {
            IdEnfermedad: idEnf,
            IdCedula: window.localStorage.getItem("id"),
            FechaEnfermedad: fEnf
        };
        $http.post("http://localhost:64698/api/EnfermedadxPersona/EliminarEnfxPer", eliminarEnfermedad)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/mywebsite/WebCliente/main.html";
            }, function errorCallback(response) {
                console.log(response);
            });

    };
});
