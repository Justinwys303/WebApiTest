(function (app) {
    var ListController = function ($scope) {
        $scope.message = "Hello,world";
    };
    app.controller("ListController", ListController);
}(angular.module("atTheMovies")));