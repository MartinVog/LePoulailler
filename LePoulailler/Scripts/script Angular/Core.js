
var LePoulailler = angular.module('LePoulailler', []);


LePoulailler.controller('coreController', function ($scope) {

    $scope.firstName = "";
    $scope.firstName = 12;
    $scope.firstName = true;
    $scope.firstName = [];





    $scope.ingredient = {
        Id: 12334,
        Nom: "Tomate",
        Code : "tomate",
        Prix: 1.25,
        HaveLactose:false
    };





    $scope.firstName = "";
  


    $scope.calcule = function () {

        $scope.resultat = $scope.chiffre1 + $scope.chiffre2;

    };



    $scope.firstName = "John";
    $scope.lastName = "Doe";


});