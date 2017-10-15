var receta = angular.module('Recetas', []);
receta.controller("recetasController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Receta/GetRecetasId?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.misrecetas = response.data;
            console.log("Geted");
        });
    $scope.deleteReceta = function (idReceta) {
        var dR = { IdReceta: idReceta };
        $http.post("http://localhost:64698/api/Receta/DeleteReceta", dR)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/mywebsite/WebCliente/recetas.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    };
    $scope.moveToIdRec = function (idReceta) {
        window.localStorage.setItem("idReceta", idReceta);
        window.location = "http://localhost:64698/mywebsite/WebCliente/receta.html";
    };
    $scope.addReceta = function (idReceta) {
        window.location = "http://localhost:64698/mywebsite/WebCliente/addreceta.html";
    };
    
});
receta.controller("rController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/MedicamentoxReceta/GetMedicamentosxReceta?id=' + window.localStorage.getItem("idReceta"))
        .then(function (response) {
            console.log("Geting", window.localStorage.getItem("idPedido"));
            $scope.medicinas = response.data;
            console.log("Geted", $scope.medicinas);
        });


    $scope.updateReceta = function () {
        angular.forEach($scope.medicinas, function (value, key) {
            var strIdElem = 'med' + value.IdMedicamento;
            var cantidad = angular.element(document.getElementById(strIdElem)).val();
            if (cantidad > 0 && cantidad != '') {
                var pxm = {
                    IdPedido: window.localStorage.getItem("idReceta"),
                    IdMedicamento: value.IdMedicamento,
                    Cantidad: cantidad
                }
                console.log("pxm", pxm);
                $http.post("http://localhost:64698/api/MedicamentoxReceta/UpdateMedicamentoxReceta", pxm)
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }
        });

    };
});
