var app = angular.module('SearchFresherJobsApp', []);

app.controller('homeCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.jobsList = [];

    //this is to swicth between the two functions based on the page is active
    var buttonElement = angular.element(document.querySelector('#btnSave'));
    if (window.location.pathname === URLvariable || (window.location.pathname === URLvariable + "/")) {
        buttonElement.attr('ng-click', "redirectForm()");
    } else {
        buttonElement.attr('ng-click', "searchJobs()");
    }

    //home page form to redirect
    $scope.redirectForm = function () {
        window.location.href = URLvariable+"search?keyword=" + $scope.keyword + "&location=" + $scope.location;
    }

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }


    $scope.searchString = localStorage.getItem('searchString');
    //search form to show data
    $scope.searchJobs = function () {
        $scope.keyword = getParameterByName('keyword');
        $scope.location = getParameterByName('location');
        $http.get(searchApiUrl + "GetJobDataForSearch?keyword=" + $scope.keyword + "&location=" + $scope.location).then(function (result) {
            $scope.jobsList = result.data;
            $('.body-content').removeClass('hidden');
        });
        $scope.setRecentSearch($scope.keyword, $scope.location);
        $scope.recentSearches = [];
        if ($scope.searchString != null) {
            $scope.recentSearchesString = $scope.searchString.split(',');
            $scope.recentSearchesURL = $scope.searchStringURL.split(',');
            for (var i = 0; i < $scope.recentSearchesString.length; i++) {
                $scope.recentSearches.push({
                    'searched': $scope.recentSearchesString[i],
                    'URL': $scope.recentSearchesURL[i]
                })
            }
        } else if ($scope.searchString == null) {
            $scope.recentSearches = ''
        }
    }
    $scope.setRecentSearch = function (keywords, location) {
        var string = '';
        if (keywords !== '' && location !== '') {
            string = keywords + ' jobs in ' + location;
        } else if (location !== '') {
            string = location;
        } else if (keywords !== '') {
            string = keywords;
        } else if (keywords == '' && location == '') {
            string = '';
        }
        stringURL = window.location.href;
        $scope.searchString = localStorage.getItem('searchString');
        $scope.searchStringURL = localStorage.getItem('searchStringURL');

        if (string !== '') {
            if ($scope.searchString == null) {
                $scope.searchStringURL = window.location.href;
                $scope.searchString = string;
            } else {
                $scope.searchStringURL = stringURL + ' , ' + $scope.searchStringURL;
                $scope.searchString = string + ',' + $scope.searchString;
            }
            if ($scope.searchString.split(',').length > 10) {
                $scope.searchString = $scope.searchString.split(',');
                $scope.searchString.splice(10, 1);
                console.log($scope.searchString);
            }
            
            console.log(typeof $scope.searchString)
            localStorage.setItem('searchString', $scope.searchString);
            localStorage.setItem('searchStringURL', $scope.searchStringURL);
            //localStorage.removeItem('searchString');
            //localStorage.removeItem('searchStringURL');
        }
    }

    $scope.searchJobs();

    $scope.JobListUrls = [
        {
            'title': 'Fresher jobs in Chennai',
            'location': 'Chennai'
        },
        {
            'title': 'Fresher jobs in Gurgaon',
            'location': 'Gurgaon'
        },
        {
            'title': 'Fresher jobs in Bengaluru',
            'location': 'Bengaluru'
        },
        {
            'title': 'Fresher jobs in Hyderabad',
            'location': 'Hyderabad'
        },
        {
            'title': 'Fresher jobs in Kolkata',
            'location': 'Kolkata'
        },
        {
            'title': 'Fresher jobs in Delhi',
            'location': 'Delhi'
        },
        {
            'title': 'Fresher jobs in Mumbai',
            'location': 'Mumbai'
        },
        {
            'title': 'Fresher jobs in Noida',
            'location': 'Noida'
        },
        {
            'title': 'Fresher jobs in Pune',
            'location': 'Pune'
        },
        {
            'title': 'Fresher jobs in Chandigarh',
            'location': 'Chandigarh'
        }
    ]

}]);