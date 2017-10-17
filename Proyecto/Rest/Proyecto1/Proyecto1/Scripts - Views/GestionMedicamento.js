var GestionMedicamento = angular.module('GestionMedicamento', []);

GestionMedicamento.controller('GestionMedicamentoController', function ($scope, $http) {
    console.log("Gestion Medicamento");
    $http.get("http://localhost:64698/api/CasaFarmaceutica/GetAllNombresCasasFarmaceuticas")
        .then(function (response) {
            console.log("Getting");
            $scope.casas = response.data;
            console.log("Getted");
        });


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
        $http.get("http://localhost:64698/api/CasaFarmaceutica/GetIdCasaFarmaceutica?nombre=" + $scope.casa)
            .then(function (response) {
                $scope.IdCasa = response.data;
                $http.post("http://localhost:64698/api/Medicamento/PostMedicamento", Medicamento)
                    .then(function successCallback(response) {
                        $http.get('http://localhost:64698/api/Medicamento/GetLastMedicamentoId')
                            .then(function successCallback(responseget) {
                                var idData = responseget.data;
                                console.log(idData);
                                var medicamentoxCasaFarmaceutica = {
                                    IdMedicamento: idData,
                                    IdCasaFarmaceutica: $scope.IdCasa,
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
                                                window.location = "http://localhost:64698/mywebsite/Administrador/GestionMedicamentos/GestionMedicamentos.html";
                                            }, function errorCallback(response) {
                                            });
                                    }, function errorCallback(response) {
                                    });
                            });

                    }, function errorCallback(response) {
                        console.log(response);
                    });
            });
    }

});

GestionMedicamento.controller("EliminarController", function ($scope, $http, $location) {
    $http.get("http://localhost:64698/api/Medicamento/GetAllNombresMedicamentosxSucursal?id=" + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            console.log("Getting");
            $scope.medicamentos = response.data;
            console.log("Getted");
        });

    $scope.eliminar = function () {
        $http.get("http://localhost:64698/api/Medicamento/GetMedicamentoID?nombre=" + $scope.medicamento)
            .then(function (response) {
                console.log("Getting");
                $scope.IDM = response.data;
                console.log("Getted", $scope.IDM);

                $http.put("http://localhost:64698/api/MedicamentoxSucursal/PutLogicDelete", $scope.IDM).then(function successCallback(response) {
                    console.log(response);
                }, function errorCallback(response) {
                    console.log(response);
                });
                $http.put("http://localhost:64698/api/Medicamento/PutLogicDelete", $scope.IDM).then(function successCallback(response) {
                    console.log(response);
                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionMedicamentos/GestionMedicamentos.html";
                }, function errorCallback(response) {
                    console.log(response);
                });
            });

        
    }

});

GestionMedicamento.controller('ModificarController', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $http.get("http://localhost:64698/api/Medicamento/GetAllNombresMedicamentosxSucursal?id=" + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            console.log("Getting");
            $scope.medicamentos = response.data;
            console.log("Getted");
            console.log($scope.medicamento)
        });
    $scope.buscarCasa = function () {
        $http.get("http://localhost:64698/api/CasaFarmaceutica/GetAllNombresCasasFarmaceuticasxMedicamento?nombre=" + $scope.medicamento)
            .then(function (response) {
                console.log("Getting");
                $scope.casas = response.data;
                console.log("Getted");
            });
    }

    $scope.buscar = function () {
        $http.get("http://localhost:64698/api/CasaFarmaceutica/GetIdCasaFarmaceutica?nombre=" + $scope.casa)
            .then(function (response) {
                $scope.IdCasa = response.data;
                $http.get("http://localhost:64698/api/Medicamento/GetMedicamentoID?nombre=" + $scope.medicamento)
                    .then(function (response) {
                        console.log("Getting");
                        $scope.IDM = response.data;
                        console.log("Getted");

                        var data = {
                            IdMedicamento: $scope.IDM,
                            IdSucursal: Number(window.localStorage.getItem("idSucursal")),
                            IdCasaFarmaceutica: $scope.IdCasa,
                        }

                        console.log(data);

                        $http.get("http://localhost:64698/api/Medicamento/GetMedicamentosxRelacion?idm=" + data.IdMedicamento + "&" + "ids=" + data.IdSucursal + "&" + "idc=" + data.IdCasaFarmaceutica)
                            .then(function (response) {
                                console.log("Geting");
                                $scope.DatosMedicamentos = response.data;
                                console.log("Informacion Obtenida", response.data);
                            }, function errorCallback(response) {
                                console.log(response);
                            });


                    });
            });


    };

    $scope.modificar = function () {

        console.log("Modificar Medicamento");
        var pres = angular.element(document.getElementById("prescripcion")).val();
        var cant = angular.element(document.getElementById("cantidad")).val();
        var pP = angular.element(document.getElementById("pProveedor")).val();
        var pS = angular.element(document.getElementById("pSucursal")).val();
        if (pres != '' && cant != '' && pP != '' &&
            pS != '') {
            var editMedicamento = {
                IdMedicamento: $scope.IDM,
                Nombre: $scope.medicamento,
                NecesitaReceta: Number(pres)
            };
            var editMXCF = {
                IdMedicamento: $scope.IDM,
                IdCasaFarmaceutica: $scope.IdCasa,
                PrecioProveedor: pP,
            }
            var editMXS = {
                IdMedicamento: $scope.IDM,
                IdSucursal: Number(window.localStorage.getItem("idSucursal")),
                PrecioSucursal: Number(pS),
                Cantidad: Number(cant),
            }
            console.log(editMedicamento)
            console.log(editMXCF)
            console.log(editMXS)

            $http.post("http://localhost:64698/api/Medicamento/UpdateReceta", editMedicamento)
                .then(function successCallback(response) {
                    console.log(response);
                    $http.post("http://localhost:64698/api/MedicamentoxCasaFarmaceutica/UpdateMedicamentoxCasaFarmaceutica", editMXCF)
                        .then(function successCallback(response) {
                            console.log(response);
                            $http.post("http://localhost:64698/api/MedicamentoxSucursal/UpdateMedicamentoxSucursal", editMXS)
                                .then(function successCallback(response) {
                                    console.log(response);
                                    window.location = "http://localhost:64698/mywebsite/Administrador/GestionClientes/GestionClientes.html";
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
        else {
            alert("Rellene todos los campos");
        }

    };

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