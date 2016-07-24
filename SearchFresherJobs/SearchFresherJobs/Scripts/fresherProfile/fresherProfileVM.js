app.controller('homeCtrl', ['$scope', '$http', function ($scope, $http) {
    //$scope.email = 'Sparsh';
    $scope.genderCollection = genderCollection;
    $scope.maritalStatusCollection = maritalStatusCollection;
    $scope.statesCollection = statesCollection;
    $scope.gender = genderCollection[0].id;
    $scope.maritalStatus = maritalStatusCollection[0].id;
    $scope.state = statesCollection[0].id;
    $scope.preferredLocationCollection = preferredLocationCollection;
    $scope.industryCollection = industryCollection;
    $scope.functionalAreaCollection = functionalAreaCollection;

    $scope.login = function () {
        var url = apiEndpointUrl + 'AccountAPI/Login?email=' + $scope.profileSummary + '&password=' + $scope.dob + '&userType=' + $scope.gender + $scope.maritalStatus + $scope.address + $scope.city + $scope.state;
        debugger;
        //$http.get(url).success(function () {

        //}).error(function (error) {
        //    console.log(error);
        //});
    }
}]);