var app = angular.module('myApp', ['ngRoute']);


app.controller('myController', function ($scope, $http, $location) {
    window.localStorage.clear();
    console.log(window.localStorage.getItem("id"));
        $scope.id = $scope.id;
        $scope.password = $scope.password;
        $scope.log = function (id, password) {
            console.log("Ya entre");
            console.log(id, password);
            $http.get("http://localhost:64698/api/Persona/SignInVerification?id=" + id + "&" + "contraseña=" + password)
                .then(function (response) {
                    $scope.res = response;
                    if (response.data == true) {
                        console.log("Logged");
                        window.localStorage.setItem("id", id);
                        console.log(window.localStorage.getItem("id"));
                       window.location = "http://localhost:64698/mywebsite/main.html";
                        
                    } else {
                        alert("El usuario o la contraseña no son correctos");
                    }
                });
        };
});


app.controller("mainController", function ($scope, $http, $location) {
    console.log("HOLA");
    $scope.h = "HOLA";//window.localStorage.getItem("id");
    console.log(window.localStorage.getItem("id"));

});