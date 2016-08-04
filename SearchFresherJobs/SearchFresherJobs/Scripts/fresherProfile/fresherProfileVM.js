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
    $scope.inEditMode = false;

    //Devnote: Replace the id= 1 here with actual id of member obtained from session
    $http.get(apiEndpointUrl + 'FresherProfileAPI/Get?id=3')
    .then(function (response) {
        $scope.profileSummary = response.ProfileSummary;
        $scope.genderValue = response.Gender;
        $scope.maritalStatusValue = response.MaritalStatus;
        $scope.preferredLocation = response.PreferredLocationList;
        $scope.industry = response.IndustryList;
        $scope.functionalArea = response.FunctionalAreaList;
        $scope.address = response.Address;
        $scope.city = response.City;
        $scope.state = response.State;
    });

    $scope.addProfile = function () {
        var url = apiEndpointUrl + 'FresherProfileAPI/Post';
        var data = {
            ProfileSummary: $scope.profileSummary,
            Gender: $scope.gender,
            MaritalStatus: $scope.maritalStatus,
            PreferredLocationList: $scope.preferredLocation,
            IndustryList: $scope.industry,
            FunctionalAreaList: $scope.functionalArea,
            Address: $scope.address,
            City: $scope.city,
            State: $scope.state
        }
        $http.post(url, data).success(function () {

        }).error(function (error) {
            console.log(error);
        });
    }

}]);