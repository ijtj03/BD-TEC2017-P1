var app = angular.module('MyApp', []);

app.controller('MyController', function ($scope, $http) {
    
    $scope.cedula = $scope.cedula;
    $scope.password = $scope.password;
    $scope.res;

    $scope.fun = function (id, pass) {
        console.log("Ya entre");
        console.log(id, pass);
        $http.get("http://localhost:64698/api/Persona/SignInVerification?id=" + id + "&" + "contraseña=" + pass)
            .then(function (response) {
                $scope.res = response;
                if (response.data == true) {
                    console.log("OK");
                } else {
                    console.log("Picha");
                }
            });



    };
});