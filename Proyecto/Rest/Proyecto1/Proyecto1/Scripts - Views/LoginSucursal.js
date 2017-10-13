﻿var loginsucursal = angular.module('LoginSucursal', []);


loginsucursal.controller('LoginSucursalController', function ($scope, $http, $location) {
    window.localStorage.clear();
    console.log(window.localStorage.getItem("id"));
    $scope.id = $scope.id;
    $scope.password = $scope.password;
    $scope.log = function (id, password) {
        console.log("Ya entre");
        console.log(id, password);
        $http.get("http://localhost:64698/api/Persona/SignInSucursalVerification?id=" + id + "&" + "contraseña=" + password)
            .then(function (response) {
                $scope.res = response;
                if (response.data == true) {
                    console.log("Logged");
                    window.localStorage.setItem("id", id);
                    console.log(window.localStorage.getItem("id"));
                    window.location = "http://localhost:64698/mywebsite/Sucursal/mainSucursal.html";

                } else {
                    alert("El usuario o la contraseña no son correctos");
                }
            });
    };
});

