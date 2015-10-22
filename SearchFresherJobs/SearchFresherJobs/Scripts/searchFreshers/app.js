var app = angular.module('SearchFresherJobsApp', []);

app.controller('homeCtrl', function ($scope, $http) {
    $scope.keyword = "";
    $scope.location = "";

    $scope.searchForJobs = function () {
        $http.get(searchApiUrl + "GetJobDataForSearch?keyword=" + $scope.keyword + "&location=" + $scope.location).then(function (result) {
            console.log(result.data);
        });
    }

    $scope.JobListUrls = [
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
        {
            'title': 'Vrijwilligerswerk in Amsterdam',
            'href': 'javascript:void(0)'
        },
    ]

});