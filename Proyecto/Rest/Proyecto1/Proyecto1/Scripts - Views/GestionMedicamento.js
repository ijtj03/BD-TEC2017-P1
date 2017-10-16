var GestionMedicamento = angular.module('GestionMedicamento', []);

GestionMedicamento.controller('GestionMedicamentoController', function ($scope, $http) {
    console.log("Gestion Medicamento");
    $scope.nombre = $scope.nombre;
    $scope.idCasaFarmaceutica = $scope.idCasaFarmaceutica;
    $scope.prescripcion = $scope.prescripcion;
    $scope.cantidad = $scope.cantidad;
    $scope.pProveedor = $scope.pProveedor;
    $scope.pSucursal = $scope.pSucursal;


    $scope.agregar = function () {

        var Medicamento = {
            Nombre: $scope.nombre,
            NecesitaReceta: $scope.prescripcion,
        }

        $http.post("http://localhost:64698/api/Medicamento/PostMedicamento", Medicamento)
            .then(function successCallback(response) {
                $http.get('http://localhost:64698/api/Medicamento/GetLastMedicamentoId')
                    .then(function successCallback(responseget) {
                        var idData = responseget.data;
                        console.log(idData);
                        var medicamentoxCasaFarmaceutica = {
                            IdMedicamento: idData,
                            IdCasaFarmaceutica: $scope.idCasaFarmaceutica,
                            PrecioProveedor: $scope.pProveedor,
                        }
                        console.log(medicamentoxCasaFarmaceutica)
                        var medicamentoxSucursal = {
                            IdMedicamento: idData,
                            IdSucursal: Number(window.localStorage.getItem("idSucursal")),
                            PrecioSucursal: $scope.pSucursal,
                            Cantidad: $scope.cantidad,
                        }
                        console.log(medicamentoxSucursal)
                        $http.post("http://localhost:64698/api/MedicamentoxCasaFarmaceutica/PostMedicamentoxCasaFarmaceutica", medicamentoxCasaFarmaceutica)
                            .then(function successCallback(response1) {
                                $http.post("http://localhost:64698/api/MedicamentoxSucursal/PostMedicamentoxSucursal", medicamentoxSucursal)
                                    .then(function successCallback(response2) {
                                        window.location = "http://localhost:64698/mywebsite/Administrador/GestionMedicamento/GestionMedicamento.html";
                                    }, function errorCallback(response) {
                                    });
                            }, function errorCallback(response) {
                            });
                    });
                
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionMedicamento.controller("EliminarController", function ($scope, $http, $location) {
    $scope.medicamentoId = $scope.medicamentoId;

    $scope.eliminar = function () {
        var IdMedicamento = $scope.medicamentoId;

        $http.put("http://localhost:64698/api/Medicamento/PutLogicDelete", IdMedicamento).then(function successCallback(response) {
            console.log(response);
            $http.put("http://localhost:64698/api/MedicamentoxSucursal/PutLogicDelete", IdMedicamento).then(function successCallback(response) {
                console.log(response);
                $http.put("http://localhost:64698/api/MedicamentoxCasaFarmaceutica/PutLogicDelete", IdMedicamento).then(function successCallback(response) {
                    console.log(response);
                    window.location = 'http://localhost:64698/mywebsite/Administrador/GestionMedicamentos/GestionMedicamentos.html';
                }, function errorCallback(response) {
                    console.log(response);
                });
            }, function errorCallback(response) {
                console.log(response);
            });
        }, function errorCallback(response) {
            console.log(response);
        });
    }

});

GestionMedicamento.controller('ModificarController', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $scope.IDM = $scope.IDM;
    $scope.IDC = $scope.IDC;

    $scope.buscar = function () {
        var data = {
            IdMedicamento: $scope.IDM,
            IdSucursal: Number(window.localStorage.getItem("idSucursal")),
            IdCasaFarmaceutica: $scope.IDC,
        }
        $http.get("http://localhost:64698/api/Medicamento/GetMedicamentosxRelacion?idm=" + data.IdMedicamento + "&" + "ids=" + data.IdSucursal + "&" + "idc=" + data.IdCasaFarmaceutica)
            .then(function (response) {
                console.log("Geting");
                $scope.DatosMedicamentos = response.data;
                console.log("Geted", response.data);
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionMedicamento.controller('ObtenerTodos', function ($scope, $http, $location) {
    console.log("Obtener Todos los medicamentos");
    console.log(window.localStorage.getItem("idSucursal"));
    $http.get('http://localhost:64698/api/Medicamento/GetAllMedicamentosxRelacion?id=' + window.localStorage.getItem("idSucursal"))
        .then(function successCallback(response) {
            $scope.Medicamentos = response.data;
            console.log(response.data);
        }, function errorCallback(response) {
            console.log(response);
        });

});