(function (app) {
    var DetailsController = function ($scope, movieService, $routeParams) {
        var id = $routeParams.id;
        movieService
            .getById(id)
            .then(function (data) {
                $scope.movie = data.data
            });
        $scope.edit = function () {
            $scope.edit.movie = angular.copy($scope.movie);
        }
    };
    app.controller("DetailsController", DetailsController);
}(angular.module("atTheMovies")));