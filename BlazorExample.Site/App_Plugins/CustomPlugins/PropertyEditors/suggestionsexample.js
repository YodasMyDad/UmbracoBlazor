angular.module("umbraco")
    .controller("SuggestionPluginController", function ($scope, $location, userService, assetsService, $http, $q, notificationsService) {
        // Set the variables and methods we want Blazor to access on the window object
        // as Blazor can only access that
        window.suggestionValue = () => {
            return $scope.model.value;
        };
        window.setSuggestionValue = (someValue) => {
            $scope.model.value = someValue;
        };
        window.notificationsService = notificationsService;
    });