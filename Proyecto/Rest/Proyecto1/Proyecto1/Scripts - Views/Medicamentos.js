﻿var medicamentos = angular.module('Medicamentos', []);
medicamentos.controller("medicamentosController", function ($scope, $http, $location) {
    $scope.medValues;
    window.localStorage.setItem("img", null);
   // console.log(window.localStorage.getItem("img"));
    
    $http.get('http://localhost:64698/api/MedicamentoxSucursal/GetMedicamentoxSucursal?id=' + window.localStorage.getItem("idSucursal"))
        .then(function (response) {
            console.log("IdSuc", window.localStorage.getItem("idSucursal"));
            $scope.medValues = response.data;
            $scope.medicamentosid = $scope.medValues;
        }); 

    $scope.agregarimg = function () {
        var file = document.getElementById('recImg').files[0];
        var reader = new FileReader();
        reader.onloadend = function () {
            console.log('RESULT', reader.result);
            window.localStorage.setItem("img", reader.result);
            console.log(window.localStorage.getItem("img"));

        }
        
        reader.readAsDataURL(file);
    }

    
    $scope.rePedido = function () {
        var fRec = angular.element(document.getElementById("fechaRec")).val();
        if (fRec != '') {
            var pedido = {
                IdCedula: window.localStorage.getItem("id"),
                IdSucursal: window.localStorage.getItem("idSucursal"),
                Estado: 0,
                FechaRecojo: fRec,
                RecetaImg: window.localStorage.getItem("img")
            };
            
            $http.post("http://localhost:64698/api/Pedido/PostPedido", pedido)
                .then(function successCallback(response) {
                    console.log(response);
                    $http.get('http://localhost:64698/api/Pedido/GetLastPedidoId')
                        .then(function (response) {
                            $scope.lastId = response.data;
                            console.log($scope.lastId);
                            angular.forEach($scope.medValues, function (value, key) {
                                var strIdElem = 'med' + value.IdMedicamento;
                                var cantidadMed = angular.element(document.getElementById(strIdElem)).val();
                                var updateCantidad = value.Cantidad - cantidadMed;
                                if (cantidadMed > 0 && cantidadMed != '') {
                                    var PedidoxMedicamento = {
                                        IdPedido: $scope.lastId,
                                        IdMedicamento: value.IdMedicamento,
                                        Cantidad: cantidadMed,
                                        RecetaImg: null
                                    };
                                    

                                
                                    var newCantidad = {
                                        IdSucursal: window.localStorage.getItem("idSucursal"),
                                        IdMedicamento: value.IdMedicamento,
                                        Cantidad: updateCantidad
                                    };

                                    console.log(PedidoxMedicamento);
                                    $http.post("http://localhost:64698/api/PedidoxMedicamento/PostPedidoxMedicamento", PedidoxMedicamento)
                                        .then(function successCallback(response) {
                                            console.log(response);
                                            $http.post("http://localhost:64698/api/MedicamentoxSucursal/UpdateCantidad", newCantidad)
                                                .then(function successCallback(response) {
                                                    console.log(response);
                                                }, function errorCallback(response) {
                                                    console.log(response);
                                                });
                                        }, function errorCallback(response) {
                                            console.log(response);
                                        });
                                }

                            });
                            /*.then(function (response) {
                                window.location = "http://localhost:64698/mywebsite/WebCliente/pedidos.html";
                            });*/


                        });
                }, function errorCallback(response) {
                    console.log(response);
                });

        } else {
            alert("Debe elegir  la  fecha de recojo");
        }
    };

});
