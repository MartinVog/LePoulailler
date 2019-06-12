
LePoulailler.controller('grid.sandwichController', function ($scope, $http) {
    

    var getInfoGrid = function () {
        $scope.data.isLoading = true;
        var url = "/Sandwich/GetInfoGrid";

        var dataToSend = {};

        $http.post(url, dataToSend).then(function success(response) {
            if (!response.data.erroMessageList || response.data.erroMessageList.length === 0) {
                //Todo success

                console.log(response.data);
                $scope.data.SandwichsList = response.data.SandwichsList;
            }
            else {
                //Todo error
            }
            $scope.data.isLoading = false;
        }, function error(response) {
            $scope.data.errorMessages = response.statusText;
            $scope.data.isLoading = false;
        });

    };

    $scope.init = function () {
        $scope.data = {};

        getInfoGrid();

    };

    $scope.init();
}).controller('edition.sandwichController', function ($scope, $http) {


    var getInfoEdition = function () {
        $scope.data.isLoading = true;
        var url = "/Sandwich/GetInfoEdition";

        var dataToSend = {
            sandwichId: $scope.data.SandwichId
        };

        $http.post(url, dataToSend).then(function success(response) {
            if (!response.data.erroMessageList || response.data.erroMessageList.length === 0) {
                //Todo success

                console.log(response.data);
                $scope.data.SandwichsDico = response.data.sandwichsDico;
            }
            else {
                //Todo error
            }
            $scope.data.isLoading = false;
        }, function error(response) {
            $scope.data.errorMessages = response.statusText;
            $scope.data.isLoading = false;
        });
    };

    $scope.init = function () {
        $scope.data = {};

        getInfoEdition();
    };

    $scope.init();
});