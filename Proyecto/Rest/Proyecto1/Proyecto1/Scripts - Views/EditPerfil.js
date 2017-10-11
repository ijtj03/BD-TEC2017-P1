var editP = angular.module('EditPerfil', []);

editP.controller("editController", function mainController($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Persona/GetPersona?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.perfil = response.data;
            console.log("Geted", response.data);
        });

    $scope.editPerfil = function () {
        console.log("Editar perfil");
        var tel = angular.element(document.getElementById("telefono")).val();
        var prov = angular.element(document.getElementById("provincia")).val();
        var can = angular.element(document.getElementById("canton")).val();
        var dis = angular.element(document.getElementById("distrito")).val();
        var dir = angular.element(document.getElementById("direccion")).val();
        var pass = angular.element(document.getElementById("password")).val();
        if (tel != '' && prov != '' && can != '' &&
            dis != '' && dir != '' && pass != '') {
            var editP = {
                Contraseña: pass,
                Telefono: tel,
                DescripcionDireccion: dir,
                Provincia: prov,
                Canton: can,
                Distrito: dis,
                IdCedula: window.localStorage.getItem("id")
            };
            $http.post("http://localhost:64698/api/Persona/UpdatePersona", editP)
                .then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/main.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
        else {
            alert("Rellene todos los campos");
        }
        
    };
});