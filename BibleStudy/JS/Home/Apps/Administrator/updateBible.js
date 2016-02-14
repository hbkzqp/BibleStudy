(function () {
    'use strict';

    var app = angular.module('updateBible', []);
    var bible;
    app.controller("bibleContent", function ($scope, $http)
    {
        $scope.dateToUpdate = "";
        $scope.content = "";
        $scope.imagePath = "";
        $scope.newImagePath = "";
        $scope.getContent = function()
        {
            var dat = $scope.dateToUpdate;
            var year = dat.getFullYear();
            var month;
            if (dat.getMonth() > 8)
            {
                month = dat.getMonth();
            }
            else
            {
                var mon = dat.getMonth()+1;
                month = "0" + mon;
            }
            var day = dat.getDate();
            var dateData = year + "-" + month + "-" + day;
            //$http({
            //    method: 'GET',
            //    url: '/api/Bible/GetName',
            //    data: {"data":"aaaaaa"}
            //}).then(function successCallback(response) {
            //    var data = response.data;
            //    $scope.content = data.content;
            //    $scope.imagePath = data.imagePath;
            //}, function errorCallback(response) {
            //    alert(response.statusText);
            //});
            var data;
            getBible(dateData);
            $scope.content = bible.content;
            $scope.imagePath = bible.imagePath;
        }
    });

    function getBible(date)
    {
        $.ajax(
       {
           url: "/api/BibleUpdate/GetName",
           type: "get",
           data: { "date": date },
           async: false,
           success: function (data) {
               bible = data;
           }

       });
    }
})();
