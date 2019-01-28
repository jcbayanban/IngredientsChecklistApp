var ingredientApp = angular.module('ingredientApp', ['ui.bootstrap', 'ngCookies']);
ingredientApp.factory('authInterceptorService', ['$q', '$location', '$window', 'userToken',
    '$cookies', function ($q, $location, $window, userToken, $cookies) {
        debugger;
        var authInterceptorServiceFactory = {};
        var _request = function (config) {
            config.headers = config.headers || {};
            var authData = userToken.get();
            if (authData) {
                config.headers.Authorization = 'Bearer ' + authData;
            }
            return config;
        }
        var _responseError = function (rejection) {            
            if (rejection.status === 401) {
                $window.location.href = '/Account/Login';

            }
            return $q.reject(rejection);
        }
        authInterceptorServiceFactory.request = _request;
        authInterceptorServiceFactory.responseError = _responseError;
        return authInterceptorServiceFactory;
    }])
    .factory('userToken', ['$cookies', '$rootScope', function ($cookies, $rootScope) {
        debugger;
        var currentToken = "";
        return {
            set: function (token) {
                currentToken = token;
                var expireDate = new Date();
                expireDate.setDate(expireDate.getDate() + 1);
                $cookies.put('AAWtoken', token, { 'expires': expireDate, path: '/' });
            },
            get: function () {
                currentToken = $cookies.get("AAWtoken");
                return currentToken;
            },
            clear: function () {
                currentToken = "";
                $cookies.remove("AAWtoken");
                $cookies.remove("CurrentUserName");

                var cookies = $cookies.getAll();
                angular.forEach(cookies, function (v, k) {
                    $cookies.remove(k, { path: '/' });
                });

            },
            getcurrentusername: function () {
                var currentUserName = $cookies.get("CurrentUserName");
                return currentUserName;
            },
            setcurrentusername: function (username) {
                debugger;
                var expireDate = new Date();
                expireDate.setDate(expireDate.getDate() + 1);
                $cookies.put('CurrentUserName', username, { 'expires': expireDate, path: '/' });
                $rootScope.currentUserName = username;
            },
        }
    }]);

ingredientApp.controller('applicationController', function ($rootScope, $scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {
    //$rootScope.currentUserName = userToken.getcurrentusername();
    //$scope.currentActiveUser;
    //$scope.activeCompany;
    //$scope.listUserCompany;
    //$scope.getActiveUser = function () {
    //    $http({
    //        method: 'GET',
    //        url: "/api/user/getactiveuser",
    //    }).then(function (response) {            
    //        $scope.currentActiveUser = response.data;
    //    }).catch(function (response) {
    //        $scope.logOut();
    //    });
    //};
    //$scope.getActiveUser();



    $scope.logOut = function () {
        userToken.clear();
        $window.location.href = '/Account/Login';
    };

    //$scope.validateForm = function (form_error_object) {
    //    angular.forEach(form_error_object, function (objArrayFields, errorName) {
    //        angular.forEach(objArrayFields, function (objArrayField, key) {
    //            objArrayField.$setDirty();
    //        });
    //    });
    //};
});


ingredientApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

