
'use strict';



var app = angular.module('BibleHome', []);
app.controller("HomeController", function ($scope, $http)
{
    $http({
        method: 'GET',
        url: '/api/Home/Get'
    }).then(function successCallback(response)
    {
        var data = response.data;
        $scope.bibleList = data.bible;
        $scope.priestList = data.prists;
        $scope.background = data.photo;
        var bibleShowList = new Array();
        for (var i = 0; i < $scope.bibleList.length; i++)
        {
            if (($scope.bibleList)[i].dateWeek == getDay())
            {
                bibleShowList.push(true);
            }
            else
            {
                bibleShowList.push(false);
            }

        }
        $scope.BibleShowList = bibleShowList;
        var priestShowList = new Array();
        var priests = $scope.priestList;
        for (var i = 0; i < priests.length; i++)
        {
            priestShowList.push(true);
        }
        $scope.PriestShowList = priestShowList;


    }, function errorCallback(response)
    {
        alert(response.statusText);
    });
    $scope.priestShow = function (index) {
        $scope.PriestShowList[index] = !($scope.PriestShowList[index]);
    }
}
)

