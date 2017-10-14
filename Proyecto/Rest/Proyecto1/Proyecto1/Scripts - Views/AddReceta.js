var addRec = angular.module('AddReceta', []);
addRec.controller("addRecetaController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Medicamento/GetAllMedicamentos')
        .then(function (response) {
            console.log("Geting");
            $scope.medicinas = response.data;
            console.log("Geted");
        });
    $scope.addRec = function (idSucursal) {
        var recImg = angular.element(document.getElementById("recImg")).val();
        if (recImg == '') {
            alert("Debe seleccionar una imagen");
        }
        else {
            var rec = {
                IdCedula: window.localStorage.getItem("id"),
                RecetaImage: recImg
            };
            $http.post("http://localhost:64698/api/Receta/PostReceta", rec)
                .then(function successCallback(response) {
                    console.log("PostPedido",response)
                    $http.get('http://localhost:64698/api/Receta/GetLastId')
                        .then(function (response) {
                            console.log("Geting");
                            $scope.idRec = response.data;
                            console.log("Geted");
                            angular.forEach($scope.medicinas, function (value, key) {
                                var strIdElem = 'med' + value.IdMedicamento;
                                var cantidadMed = angular.element(document.getElementById(strIdElem)).val();
                                if (cantidadMed > 0 && cantidadMed != '') {
                                    var mxr = {
                                        IdPedido: $scope.idRec,
                                        IdMedicamento: value.IdMedicamento,
                                        Cantidad: cantidadMed
                                    };
                                    $http.post("http://localhost:64698/api/MedicamentoxReceta/PostMedicamentoxReceta", mxr)
                                        .then(function successCallback(response) {
                                            console.log("PostMedicamento", response);
                                        }, function errorCallback(response) {
                                            console.log(response);
                                        });
                                }
                            });
                        });
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
    };

});