(function (app) {
    var EditController = function ($scope, movieService) {
        $scope.isEditable = function () {
            return $scope.edit && $scope.edit.movie;
        };
        $scope.cancel = function () {
            $scope.edit.movie = null;
        };
        $scope.save = function () {
            if ($scope.edit.movie.id) {
                updateMovie();
            } else {
                createMovie();
            }
        };
        var updateMovie = function () {
            movieService.update($scope.edit.movie)
                .then(function () {
                    angular.extend($scope.movie, $scope.edit.movie);
                    $scope.edit.movie = null;
                });
        };
        var createMovie = function () {
            movieService.create($scope.edit.movie)
                .then(function (movie) {
                    $scope.movies.push(movie);
                    $scope.edit.movie = null;
                });
        };
    };
    app.controller("EditController", EditController);
}(angular.module("atTheMovies")));