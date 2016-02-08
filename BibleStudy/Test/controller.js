(function () {
    'use strict';

    var myApp = angular.module('aTest', []);
    myApp.controller("cont",function($http)
    {
        $http({
                    method: 'GET',
                    url: '/api/Home/Get'
        }).then(function successCallback(response) {
                var a = response;
                    // this callback will be called asynchronously
                    // when the response is available
                }, function errorCallback(response) {
                    alert(response.statusText);
                });
    }
    );

    //angular
    //    .module('aTest')
    //    .controller('cont', controller);

    //controller.$inject = ['$location']; 
    //controller.$inject = ['$http'];
    //function controller($http)
    //{
    //    $http({
    //        method: 'GET',
    //        url: '/api/Home'
    //    }).then(function successCallback(response) {
    //        // this callback will be called asynchronously
    //        // when the response is available
    //    }, function errorCallback(response) {
    //        // called asynchronously if an error occurs
    //        // or server returns response with an error status.
    //    });
        
    //}
})();
