var app = angular.module("MyApp", []);

app.controller('myController', function ($scope, $http) {
    $scope.date = $scope.date;

    

    $scope.add = function () {

        
        

       var file = document.getElementById('file').files[0];
       var reader = new FileReader();
       reader.onloadend = function () {
           //console.log('RESULT', reader.result);
           $scope.base64 = reader.result;

           var j = {
               IdCedula: 116880380,
               IdSucursal: 2,
               Estado: 0,
               Recogido: 0,
               Preparado: 0,
               FechaREcojo: $scope.date,
               RecetaImg: $scope.base64
           }
           
           console.log(j);
           $http.post("http://localhost:64698/api/Pedido/PostPedidoImage", j)
               .then(function successCallback(response) {
                   //console.log(response);
                   //window.location = "http://localhost:64698/mywebsite/WebCliente/login.html";
               }, function errorCallback(response) {
                   console.log(response);
               });
       }
       reader.readAsDataURL(file);

       

     

      
        
    }

    $scope.image = function () {
        console.log("ENTRE");
        $http.get(" http://localhost:64698/api/Pedido/GetImagePedido")
            .then(function (response) {
                //console.log(response.data);
                /*var base64 = $base64.decode(response.data);
                console.log(base64);*/
                $scope.base = response.data;
                console.log($scope.base);
            });
    }
});




