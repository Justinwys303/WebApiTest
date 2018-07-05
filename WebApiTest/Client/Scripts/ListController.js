(function (app) {
    var ListController = function ($scope, movieService) {
        movieService
            .getAll()
            .then(function (data) {
                $scope.movies = data.data;
            })
            .catch(function (result) {
                alert(result.data.message);
            });
        $scopte.create = function () {
            $scope.edit = {
                movie: {
                    Title: "",
                    Runtime: 0,
                    ReleaseYear: new Date().getFullYear()
                }
            };
        };
        $scope.delete = function (movie) {
            movieService
                .delete(movie)
                .then(function () {
                    removeMovieById(movie.id);
                    window.location.reload();
                });
        }
        var removeMovieById = function (id) {
            for (var i = 0; i < $scope.movies.length; i++) {
                if ($scope.movies[i].Id == id) {
                    $scope.movies.splice(i, 1);
                    break;
                }
            }
        };
    };
    //ListController.$inject = ["$scope", "$http"];
    app.controller("ListController", ListController);
}(angular.module("atTheMovies")));