var GestionMedicamento = angular.module('GestionMedicamento', []);

GestionMedicamento.controller('GestionMedicamentoController', function ($scope, $http) {
    console.log("Gestion Medicamento");
    $scope.nombre = $scope.nombre;
    $scope.idCasaFarmaceutica = $scope.idCasaFarmaceutica;
    $scope.prescripcion = $scope.prescripcion;
    $scope.cantidad = $scope.cantidad;
    $scope.precioProveedor = $scope.precioProveedor;


    $scope.agregar = function () {

        var Medicamento = {
            Nombre: $scope.nombre,
            NecesitaReceta: $scope.prescripcion,
        }

        console.log(Rol);

        $http.post("http://localhost:64698/api/Medicamento/PostMedicamento", Medicamento)
            .then(function successCallback(response) {
                var medicamento = response.data;
                var medicamentoxCasaFarmaceutica = {
                    IdMedicamento = medicamento.IdMedicamento,
                    IdCasaFarmaceutica = $scope.idCasaFarmaceutica,
                    PrecioProveedor = $scope.precioProveedor,
                }
                $http.post("http://localhost:64698/api/MedicamentoxCasaFarmaceutica/PostMedicamentoxCasaFarmaceutica", medicamentoxCasaFarmaceutica)
                    .then(function successCallback(response) {
                        console.log(response);
                        window.location = "http://localhost:64698/Administrador/GestionMedicamento/GestionMedicamento.html";
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionMedicamento.controller("EliminarController", function ($scope, $http, $location) {
    $scope.IdRol = $scope.IdRol;

    $scope.eliminar = function () {
        var IdRol = $scope.IdRol;

        console.log(IdRol);

        $http.put("http://localhost:64698/api/Rol/PutLogicDelete", IdRol).then(function successCallback(response) {
            console.log(response);
            window.location = "http://localhost:64698/Administrador/GestionRoles/GestionRoles.html";
        }, function errorCallback(response) {
            console.log(response);
        });
    }

});

GestionMedicamento.controller('ModificarController', function ($scope, $http, $location) {
    console.log("Buscar Usurario");
    $scope.IdRol = $scope.IdRol;
    $scope.nombre = $scope.nombre;
    $scope.descripcion = $scope.descripcion;

    $scope.buscar = function () {
        var IdRol = $scope.IdRol;
        console.log(IdRol);
        $http.Get('http://localhost:64698/api/Rol/GetRol?id=' + window.localStorage.getItem("idRol"))
            .then(function successCallback(response) {
                console.log("Encontro el data");
                $scope.buscar = response.data;
            }, function errorCallback(response) {
                console.log(response);
            });
    }

});

GestionMedicamento.controller('ObtenerTodos', function ($scope, $http, $location) {
    console.log("Obtener Todos los medicamentos");
    $http.get('http://localhost:64698/api/Medicamento/GetAllMedicamentos')
        .then(function successCallback(response) {
            $scope.Medicamentos = response.data;
        }, function errorCallback(response) {
            console.log(response);
        });

});