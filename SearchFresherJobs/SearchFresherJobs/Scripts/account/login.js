app.controller('homeCtrl', ['$scope', '$http', function ($scope, $http, $rootScope) {
    $scope.login = function () {
        var url = apiEndpointUrl + 'AccountAPI/Login?email=' + $scope.email + '&password=' + $scope.password + '&userType=' + $scope.userType;
        $http.get(url).success(function (data) {
            localStorage.setItem("PublicUserProfileId", data.publicUserProfileId);
            location.href = "/Home/Index";
        }).error(function (error) {
            console.log(error);
        });
    }
}]);