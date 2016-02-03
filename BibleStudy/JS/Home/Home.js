
'use strict';

var app = angular.module('BibleHome', [
    // Angular modules 
    'ngRoute'
    // Custom modules 

    // 3rd Party Modules

]);
app.controller("HomeController", function ($scope, $http)
{
    $http({
        method: 'GET',
        url: '/someUrl'
    }).then(function successCallback(response)
    {
        var data = response.data;
        $scope.bibleList = data.bibles;
        $scope.priestList = data.prists;
        $scope.backGround= data.photo;
    }, function errorCallback(response)
    {
        
    });

}
)

