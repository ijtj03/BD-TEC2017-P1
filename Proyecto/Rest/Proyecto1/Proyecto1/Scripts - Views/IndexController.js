var app = angular.module('MyApp', []);

app.controller('MyController', function ($scope, $http) {
    window.localStorage.setItem("id", null);
    console.log("logout");
});