ingredientApp.controller('homeController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) { 
    debugger;
    $scope.validate = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/auth/validate',
        }).then(function (response) {
            if (response.data != "") {
                //userToken.setcurrentusername(response.data);
            }
            else {
                $window.location.href = rootDir + 'Account/Login';
            }
        });
    };
    $scope.validate();

});