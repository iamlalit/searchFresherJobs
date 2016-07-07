app.controller('homeCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.email = 'Sparsh';

    $scope.login = function () {
        var url = apiEndpointUrl + 'AccountAPI/Login?email=' + $scope.email + '&password=' + $scope.password + '&userType=' + $scope.userType;
        $http.get(url).success(function () {

        }).error(function (error) {
            console.log(error);
        });
    }
}]);