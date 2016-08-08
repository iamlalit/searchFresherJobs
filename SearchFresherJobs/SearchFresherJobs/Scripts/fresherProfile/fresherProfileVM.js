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
        debugger;
        $scope.profileSummary = response.data.ProfileSummary;
        $.each(genderCollection, function (i, item) {
            if (item.id == response.data.Gender.toString()) $scope.genderValue = item.name;
        });
        $.each(maritalStatusCollection, function (i, item) {
            if (item.id == response.data.MaritalStatus.toString()) $scope.maritalStatusValue = item.name;
        });
        $.each(preferredLocationCollection, function (i, item) {
            if (item.id == response.data.PreferredLocationList.toString()) $scope.preferredLocation = item.name;
        });
        $.each(industryCollection, function (i, item) {
            if (item.id == response.data.IndustryList.toString()) $scope.industry = item.name;
        });
        $.each(functionalAreaCollection, function (i, item) {
            if (item.id == response.data.FunctionalAreaList.toString()) $scope.functionalArea = item.name;
        });
        $scope.address = response.data.Address;
        $scope.city = response.data.City;
        $.each(statesCollection, function (i, item) {
            if (item.id == response.data.State.toString()) $scope.state = item.name;
        });
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