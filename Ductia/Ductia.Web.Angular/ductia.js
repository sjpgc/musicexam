var ductia = angular.module("ductia", []);

ductia.controller("SearchController", ["$scope", "$http",
	function ($scope, $http) {
		$scope.searchResult = "";

		var searchServiceUrl = "http://localhost:2487/";
		var restfulSearchBookByPieceTitle = "search/books/{pieceName}";


		$scope.searchByName = function (name) {

			var requestedSearch = searchServiceUrl + restfulSearchBookByPieceTitle.replace("{pieceName}", name);
			$http.jsonp(requestedSearch)
				.success(function (data) {
					$scope.searchResult = data;
				})
				.error(function (data, status, headers, config) {
					$scope.searchResult = config;

					alert("error!");
					alert("status: " + status);
					alert("headers: " + headers);
					alert("config: " + config);
					alert(data);
				}
				);
		}
	}]);
