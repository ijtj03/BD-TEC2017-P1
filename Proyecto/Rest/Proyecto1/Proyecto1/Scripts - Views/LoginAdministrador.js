var loginadministrador = angular.module('LoginAdministrador', []);
loginadministrador.controller('LoginAdministradorController', function ($scope, $http) {
    window.localStorage.clear();
    console.log(window.localStorage.getItem('id'));
    $scope.id = $scope.id;
    $scope.password = $scope.password;
    $scope.log = function (id, password) {
        console.log("Ya entre");
        console.log(id, password);
        $http.get("http://localhost:64698/api/Persona/SignInAdministradorVerification?id=" + id + "&" + "contraseña=" + password)
            .then(function (response) {
                $scope.res = response;
                if (response.data == true) {
                    console.log("Logged");
                    window.localStorage.setItem("id", id);
                    $http.get("http://localhost:64698/api/Persona/GetSucursalPersona?id=" + window.localStorage.getItem("id"))
                        .then(function (response) {
                            $scope.res = response;
                            window.localStorage.setItem("idSucursal", response.data);
                            console.log(window.localStorage.getItem("id"), window.localStorage.getItem("idSucursal"));
                            window.location = "http://localhost:64698/mywebsite/Administrador/HomeAdministrador.html";
                        });


                 

                } else {
                    alert("El usuario o la contraseña no son correctos");
                }
            });
    };
    







});