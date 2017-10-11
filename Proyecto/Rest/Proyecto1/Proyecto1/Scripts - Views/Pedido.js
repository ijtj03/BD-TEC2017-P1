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
        window.location = "http://localhost:64698/mywebsite/pedido.html";
    };
});
pedidos.controller("pedidoController", function ($scope, $http, $location) {
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetMedicamentosxPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            console.log("Geting", window.localStorage.getItem("idPedido"));
            $scope.medicinas = response.data;
            console.log("Geted");
        });
});
pedidos.controller("precioController", function ($scope, $http) {
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetPrecioTotal?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            console.log("Geting");
            $scope.precio = response.data;
            console.log("Geted");
        });
});