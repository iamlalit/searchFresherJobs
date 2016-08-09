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
    $scope.preferredLocationValue = "";
    $scope.industryValue = "";
    $scope.functionalAreaValue = "";
    $scope.preferredLocation = [];
    $scope.industry = [];
    $scope.functionalArea = [];
    $scope.tempBasicProfileModel = {};



    //Devnote: Replace the id= 1 here with actual id of member obtained from session
    $http.get(apiEndpointUrl + 'FresherProfileAPI/Get?id=3')
    .then(function (response) {
        $scope.profileSummary = response.data.ProfileSummary;
        $.each(genderCollection, function (i, item) {
            if (item.id == response.data.Gender.toString()) {
                $scope.genderValue = item.name;
                $scope.gender = response.data.Gender.toString();
            }
        });
        $.each(maritalStatusCollection, function (i, item) {
            if (item.id == response.data.MaritalStatus.toString()) {
                $scope.maritalStatusValue = item.name;
                $scope.maritalStatus = response.data.MaritalStatus.toString();
            }
        });

        $.each(response.data.PreferredLocationList, function (i, storedItem) {
            $.each(preferredLocationCollection, function (i, collectionItem) {
                if (collectionItem.id == storedItem.toString()) {
                    $scope.preferredLocationValue = $scope.preferredLocationValue + collectionItem.name + ", ";
                    $scope.preferredLocation.push(storedItem.toString());
                }
            });
        });

        $.each(response.data.IndustryList, function (i, storedItem) {
            $.each(industryCollection, function (i, collectionItem) {
                if (collectionItem.id == storedItem.toString()) {
                    $scope.industryValue = $scope.industryValue + collectionItem.name + ", ";
                    $scope.industry.push(storedItem.toString());
                };
            });
        });

        $.each(response.data.FunctionalAreaList, function (i, storedItem) {
            $.each(functionalAreaCollection, function (i, collectionItem) {
                if (collectionItem.id == storedItem.toString()) {
                    $scope.functionalAreaValue = $scope.functionalAreaValue + collectionItem.name + ", ";
                    $scope.functionalArea.push(storedItem.toString());
                }
            });
        });

        $scope.address = response.data.Address;
        $scope.city = response.data.City;
        $.each(statesCollection, function (i, item) {
            if (item.id == response.data.State.toString()) {
                $scope.stateValue = item.name;
                $scope.state = response.data.State.toString();
            }
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
            $scope.inEditMode = false;
        }).error(function (error) {
            console.log(error);
        });
    }

    $scope.editProfile = function () {
        $scope.inEditMode = true;
        $scope.tempBasicProfileModel = {
            ProfileSummary: $scope.profileSummary,
            Gender: $scope.gender,
            MaritalStatus: $scope.maritalStatus,
            PreferredLocation: $scope.preferredLocation,
            Industry: $scope.industry,
            FunctionalArea: $scope.functionalArea,
            Address: $scope.address,
            City: $scope.city,
            State: $scope.state
        }
    }

    $scope.cancelEditProfile = function () {
        $scope.inEditMode = false;

        $scope.profileSummary = $scope.tempBasicProfileModel.ProfileSummary;
        $scope.gender = $scope.tempBasicProfileModel.Gender;
        $scope.maritalStatus = $scope.tempBasicProfileModel.MaritalStatus;
        $scope.preferredLocation = $scope.tempBasicProfileModel.PreferredLocation;
        $scope.industry = $scope.tempBasicProfileModel.Industry;
        $scope.functionalArea = $scope.tempBasicProfileModel.FunctionalArea;
        $scope.address = $scope.tempBasicProfileModel.Address;
        $scope.city = $scope.tempBasicProfileModel.City;
        $scope.state = $scope.tempBasicProfileModel.State;
    }

}]);