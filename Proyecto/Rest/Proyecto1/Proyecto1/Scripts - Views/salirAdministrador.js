var saliradministrador = angular.module('SalirAdministrador', []);

saliradministrador.controller('SalirAdministradorController', function ($scope, $http) {
    window.localStorage.clear;
    window.location = "http://localhost:64698/mywebsite/Administrador/LoginAdministrador.html";
});