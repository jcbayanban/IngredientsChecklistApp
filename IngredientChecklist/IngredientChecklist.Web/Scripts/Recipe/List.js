ingredientApp.controller('recipeController', function ($scope, $http, $filter, $httpParamSerializerJQLike, $cookies, userToken, $window) {

    $scope.isBusy = false;
    $scope.searchName = '';
    $scope.listRecipe;
    $scope.isNewRecipe;
    $scope.recipe;
    $scope.ingredient;

    $scope.getRecipesByName = function () {
        $http({
            method: 'GET',
            url: '/api/recipe/getlistrecipe/' + $scope.searchName,
        }).then(function (response) {
            $scope.listRecipe = response.data;
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };

    $scope.openEditRecipe = function (id) {
        debugger;
        $scope.isNewRecipe = false;
        $http({
            method: 'GET',
            url: '/api/recipe/getrecipebyid/' + id,
        }).then(function (response) {
            $scope.recipe = response.data;
            $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
            $scope.frmRecipe.$setPristine();
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
            $('#modalFrmRecipe').modal("hide");
        });

    };

    $scope.updateRecipe = function () {
        if (!$scope.frmRecipe.$valid) {
            $scope.validateForm($scope.frmRecipe.$error);
            return;
        };

        $http({
            method: 'POST',
            url: '/api/recipe/updaterecipe',
            data: $scope.recipe,
        }).then(function (response) {
            debugger;
            $('#modalFrmRecipe').modal("hide");
            angular.forEach($scope.listRecipe, function (value, key) {
                debugger;
                if (value.Id == $scope.recipe.Id) {
                    value.Name = $scope.recipe.Name;
                }
            });
        }).catch(function () {
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };


    $scope.openAddfrmRecipe = function () {
        debugger;
        $scope.recipe = { name: '', Ingredients: [] }
        $scope.isNewRecipe = true;
        if ($scope.listRecipe == undefined)
            $scope.listRecipe = new Array();
        $scope.frmRecipe.$setPristine();
        $('#modalFrmRecipe').modal({ backdrop: 'static', keyboard: false })
    };

    $scope.addRecipe = function () {
        debugger;
        if (!$scope.frmRecipe.$valid) {
            $scope.validateForm($scope.frmRecipe.$error);
            return;
        };
        $http({
            method: 'POST',
            url: rootDir + 'api/recipe/addrecipe',
            data: $scope.recipe,
        }).then(function (response) {
            debugger;
            $scope.recipe.Id = response.data;
            $scope.listRecipe.push($scope.recipe);
            $('#modalFrmRecipe').modal("hide");
            }).catch(function () {
                debugger;
            $('#modal-error').find('.modal-body').text('Unexpected error encountered');
            $('#modal-error').modal('show');
        });
    };

    $scope.addIngredient = function () {
        debugger;
        if ($scope.ingredient == undefined) {
            return;
        };
        $scope.recipe.Ingredients.push({ Name: $scope.ingredient });
        $scope.ingredient = undefined;
        //$scope.frmRecipe.$setPristine();
    };

    $scope.removeIngredient = function (index) {
        $scope.recipe.Ingredients.splice(index, 1);
    };

    $scope.validateForm = function (form_error_object) {
        angular.forEach(form_error_object, function (objArrayFields, errorName) {
            angular.forEach(objArrayFields, function (objArrayField, key) {
                objArrayField.$setDirty();
            });
        });
    };
});