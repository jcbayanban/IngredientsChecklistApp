ingredientApp.controller('cookController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {

    $scope.listIngredients;
    $scope.listRecipe;
    $scope.recipeId;
    var getRecipesByUser = function () {
        $http({
            method: 'GET',
            url: '/api/recipe/getlistrecipebyuser',
        }).then(function (response) {
            $scope.listRecipe = response.data;
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };
    getRecipesByUser();
    $scope.recipeSelected = function () {
        debugger;
        if (!$scope.recipeId) {
            $scope.listIngredients = [];
        }
        else {
            $http({
                method: 'GET',
                url: '/api/recipe/getrecipebyid/' + $scope.recipeId,
            }).then(function (response) {
                $scope.listIngredients = response.data.Ingredients;
            }).catch(function () {
                $('#modal-error').find('.modal-body').text('Unexpected error encountered');
                $('#modal-error').modal('show');
            });
        };

    };

    $scope.toggleIngredientSelection = function (event, id) {
        debugger;
        $http({
            method: 'POST',
            url: '/api/recipe/updaterecipeingredient/',
            data: { Id: id, IsChecked: event.target.checked }
        }).then(function (response) {
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });

    };

    $scope.resetIngredientSelection = function () {
        debugger;
        if (!$scope.recipeId) {
            return;
        }
        else {
            $http({
                method: 'POST',
                url: '/api/recipe/resetrecipeingredientselection/' + $scope.recipeId,
            }).then(function (response) {
                //$scope.listIngredients = response.data.ingredients;
                debugger;
                angular.forEach($scope.listIngredients, function (value, key) {
                    debugger;
                    value.IsChecked = false;
                    //var index = $scope.listConsignment.findIndex(c => c.GuidId === value.GuidId);
                    //$scope.listIngredients[index] = value;
                });
            }).catch(function () {
                $('#modal-error').find('.modal-body').text('Unexpected error encountered');
                $('#modal-error').modal('show');
            });
        };

    };
});