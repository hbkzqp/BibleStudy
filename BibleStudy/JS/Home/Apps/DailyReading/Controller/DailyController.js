(function () {
    'use strict';
    var app = angular.module('DailyReading', ['BibleManagement']);
    app.controller('DailyController', function ($scope,BibleGetService)
    {
        $scope.isBtnShow = [false, false, false, false, false, false];
        $scope.isBtnShow[getFilteredDay()] = true;
        BibleGetService.getCurrentBibles({}, function (data) 
        {
           //var data = response.data;
            $scope.bibleList = data.bible;
            var day = get_cookie(DAY);
            if (day == null)
            {
                day = 1;
            }
            $scope.dayBtnClick(day);
       })
        $scope.dayBtnClick = function(index)
        {
            var newIndex = index - 1;
            for (var i = 0; i < $scope.isBtnShow.length; i++) {
                if (i != newIndex) {
                    $scope.isBtnShow[i] = false;
                }
                else {
                    $scope.isBtnShow[i] = true;
                }
            }
            $scope.bibleContent = $scope.bibleList[newIndex].content;
        }
        //这里的逻辑在整理一下, 怎么获取bible
    });

    
})();
