var enfermedades = angular.module('Enfermedades', []);
enfermedades.controller("enfermedadesController", function ($scope, $http, $location) {
    $scope.enfValues;

    $http.get("http://localhost:64698/api/Enfermedad/GetAllEnfermedades")
        .then(function (response) {
            console.log("Getting");
            $scope.enfValues = response.data;
            console.log("Getted");
            console.log($scope.enfValues);
        });

    $scope.addEnf = function () {
        var otraEnfermedad = angular.element(document.getElementById("otraEnf")).val();
        if (otraEnfermedad != '') {
            enf = {
                Nombre: otraEnfermedad
            };
            $http.post("http://localhost:64698/api/Enfermedad/PostEnfermedad", enf)
                .then(function successCallback(response) {
                    console.log(response);
                    $http.get("http://localhost:64698/api/Enfermedad/GetLastId")
                        .then(function (response) {
                            $scope.lastId = response.data;
                            var fEnf = angular.element(document.getElementById("fechaOtraEnf")).val();
                            console.log("Fecha otra enfermedad", fEnf);
                            console.log("Idenfermedad", $scope.lastId);
                            var exp = {
                                IdCedula: window.localStorage.getItem("id"),
                                IdEnfermedad: $scope.lastId,
                                FechaEnfermedad: fEnf
                            };
                            $http.post("http://localhost:64698/api/EnfermedadxPersona/PostEnfermedadxPersona", exp)
                                .then(function successCallback(response) {
                                    console.log(response);
                                }, function errorCallback(response) {
                                    console.log(response);
                                });
                        });
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
        angular.forEach($scope.enfValues, function (value, key) {
            var strIdElem = 'fecha' + value.IdEnfermedad;
            var fechaEnf = angular.element(document.getElementById(strIdElem)).val();
            console.log("Id", strIdElem, fechaEnf);
            if (fechaEnf!=''){
                var enfermedadxPersona = {
                    IdCedula: window.localStorage.getItem("id"),
                    IdEnfermedad: value.IdEnfermedad,
                    FechaEnfermedad : fechaEnf
                };
                console.log("enfermedadxPersona", enfermedadxPersona);
                $http.post("http://localhost:64698/api/EnfermedadxPersona/PostEnfermedadxPersona", enfermedadxPersona)
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }
        });
    };

});
