var pedidos = angular.module('Pedidos', []);

pedidos.controller("pedidosController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Pedido/GetPedidos?id=' + window.localStorage.getItem("id"))
        .then(function (response) {
            console.log("Geting");
            $scope.pedidosid = response.data;
            console.log("Geted");
        });
    $scope.moveToId = function (idPedido) {
        window.localStorage.setItem("idPedido", idPedido);
        window.location = "http://localhost:64698/mywebsite/WebCliente/pedido.html";
    };
    $scope.deletePedido = function (idPedido) {
        var dP = { IdPedido: idPedido };
        $http.post("http://localhost:64698/api/Pedido/DeletePedido", dP)
            .then(function successCallback(response) {
                console.log(response);
                window.location = "http://localhost:64698/mywebsite/WebCliente/pedidos.html";
            }, function errorCallback(response) {
                console.log(response);
            });
    };
});
pedidos.controller("pedidoController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/Pedido/GetPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            $scope.pedidoSel = response.data;
            console.log("Geted pSel", response.data.FechaRecojo);
        });
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetMedicamentosxPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            console.log("Geting", window.localStorage.getItem("idPedido"));
            $scope.medicinas = response.data;
            console.log("Geted", $scope.medicinas);
        });
    
    
    $scope.updatePedido = function () {
        var fRec = angular.element(document.getElementById('fechaRec')).val();
        if (fRec!='') {
            var p = {
                FechaRecojo: fRec,
                IdPedido: window.localStorage.getItem("idPedido")
            };
            $http.post("http://localhost:64698/api/Pedido/UpdatePedido", p)
                .then(function successCallback(response) {
                    console.log(response);
                }, function errorCallback(response) {
                    console.log(response);
                });
        }
        angular.forEach($scope.medicinas, function (value, key) {
            var strIdElem = 'med' + value.IdMedicamento;
            var cantidad = angular.element(document.getElementById(strIdElem)).val();
            if (cantidad > 0 && cantidad != ''){
                var pxm = {
                    IdPedido: window.localStorage.getItem("idPedido"),
                    IdMedicamento: value.IdMedicamento,
                    Cantidad: cantidad
                }
                console.log("pxm", pxm);
                $http.post("http://localhost:64698/api/PedidoxMedicamento/UpdatePedidoxMedicamento", pxm)
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }
        });
                        
    };
});
pedidos.controller("precioController", function ($scope, $http) {
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetPrecioTotal?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            console.log("Geting");
            $scope.precio = response.data;
            console.log("Geted");
        });
});



    