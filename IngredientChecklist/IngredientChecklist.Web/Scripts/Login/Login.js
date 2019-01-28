ingredientApp.controller('loginController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {    
    $scope.userName;
    $scope.password;
    $scope.login = function () {
        debugger;
        $http({
            method: 'POST',
            url: rootDir + 'oauth/token',
            data: $httpParamSerializerJQLike({
                username: $scope.userName,
                password: $scope.password,
                grant_type: 'password'
            }),
        }).then(function (response) {
            debugger;
            userToken.set(response.data.access_token);
            $window.location.href = '/Home/Index';
        }).catch(function (response) {

            $scope.errorMessage = 'Invalid username and/or password.';
            $scope.password = '';
            $scope.isNotValid = true;
            $scope.frmLogin.$setPristine();
        });
    };

    $scope.validate = function () {
        $http({
            method: 'POST',
            url: rootDir + 'api/auth/validate',
        }).then(function (response) {
            if (response.data != "") {
                $window.location.href = '/Home/Index';
            }
        });
    };
    $scope.validate();

});