var pedidosucursal = angular.module('PedidoSucursal', []);

pedidosucursal.controller('PedidosSucursalController', function ($scope, $http) {

    $http.get('http://localhost:64698/api/Pedido/GetPedidosSucursal?id=' + window.localStorage.getItem("idsucursal"))
        .then(function (response) {
            console.log(response.data);
            $scope.pedidos = response.data;
            
        });
   // console.log($scope.pedidos);

    $scope.moveToId = function (idPedido) {
        window.localStorage.setItem("idPedido", idPedido);
        window.location = "http://localhost:64698/mywebsite/Sucursal/pedidoSucursal.html";
    };
});

pedidosucursal.controller('PedidosSucursalPreparadoController', function ($scope, $http) {

    $http.get('http://localhost:64698/api/Pedido/GetPedidosSucursalPreparado?id=' + window.localStorage.getItem("idsucursal"))
        .then(function (response) {
            console.log(response.data);
            $scope.preparados = response.data;

        });
    // console.log($scope.pedidos);

    $scope.moveToId = function (idPedido) {
        window.localStorage.setItem("idPedido", idPedido);
        window.location = "http://localhost:64698/mywebsite/Sucursal/pedidoPreparadoSucursal.html";
    };
});

pedidosucursal.controller('PedidosSucursalRecogidoController', function ($scope, $http) {

    $http.get('http://localhost:64698/api/Pedido/GetPedidosSucursalRecogido?id=' + window.localStorage.getItem("idsucursal"))
        .then(function (response) {
            console.log(response.data);
            $scope.recogidos = response.data;

        });
    // console.log($scope.pedidos);

    $scope.moveToId = function (idPedido) {
        window.localStorage.setItem("idPedido", idPedido);
        window.location = "http://localhost:64698/mywebsite/Sucursal/pedidoRecogidoSucursal.html";
    };
});

pedidosucursal.controller("PedidoSucursalController", function ($scope, $http) {
    $scope.idpedido = window.localStorage.getItem("idPedido");
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetMedicamentosxPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            $scope.medicinas = response.data;
        });



    $scope.preparado = function (id) {
        console.log("PREPARADO", id);
        $http.post("http://localhost:64698/api/Pedido/PrepararPedido?id=" + id)
            .then(function successCallback(response) {
                console.log(response);
            }, function errorCallback(response) {
                console.log(response);
            });


    };

    $scope.nopreparado = function (id) {
        console.log("NO PREPARADO",id);
        $http.post("http://localhost:64698/api/Pedido/NoPrepararPedido?id=" + id)
            .then(function successCallback(response) {
                console.log(response);
            }, function errorCallback(response) {
                console.log(response);
            });


    };



});

pedidosucursal.controller("PedidoSucursalPreparadoController", function ($scope, $http) {
    $scope.idpedido = window.localStorage.getItem("idPedido");
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetMedicamentosxPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            $scope.medicinas = response.data;
        });



    $scope.preparado = function (id) {
        console.log("PREPARADO", id);
        $http.post("http://localhost:64698/api/Pedido/PrepararPedido?id=" + id)
            .then(function successCallback(response) {
                console.log(response);
            }, function errorCallback(response) {
                console.log(response);
            });


    };

    $scope.nopreparado = function (id) {
        console.log("NO PREPARADO", id);
        $http.post("http://localhost:64698/api/Pedido/NoPrepararPedido?id=" + id)
            .then(function successCallback(response) {
                console.log(response);
            }, function errorCallback(response) {
                console.log(response);
            });


    };

    $scope.recoger = function (id) {
        console.log("RECOGER", id);
        $http.post("http://localhost:64698/api/Pedido/RecogerPedido?id=" + id)
            .then(function successCallback(response) {
                console.log(response);
            }, function errorCallback(response) {
                console.log(response);
            });


    };





});




pedidosucursal.controller("PedidoSucursalRecogidoController", function ($scope, $http) {
    $scope.idpedido = window.localStorage.getItem("idPedido");
    $http.get('http://localhost:64698/api/PedidoxMedicamento/GetMedicamentosxPedido?id=' + window.localStorage.getItem("idPedido"))
        .then(function (response) {
            $scope.medicinas = response.data;
        });
});