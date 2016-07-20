app.controller('homeCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.registerUser = function () {
        var emailRegex = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!emailRegex.test($scope.email)) {
            alert("Invalid email address");
            return;
        }
        var url = apiEndpointUrl + 'AccountAPI/Register?email=' + $scope.email + '&password=' + $scope.password + '&firstName=' + $scope.firstName + '&lastName=' + $scope.lastname + '&userType=' + $scope.userType;
        $http.get(url).success(function (data) {
            localStorage.setItem("PublicUserProfileId", data.publicUserProfileId);
            location.href = "/Home/Index";
        }).error(function (error) {
            console.log(error);
        });
    }
}]);