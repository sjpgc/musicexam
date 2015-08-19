(function() {
	'use strict';

	angular.module('ductia',
		['ngAnimate', 'ui.bootstrap'])
		.controller("SearchController", [
			"$scope", "$http",
			function($scope, $http) {
				$scope.grades = [1, 2, 3, 4, 5, 7, 8];

				$scope.searchResult = "";

				var searchServiceUrl = "http://localhost:2487/";
				var restfulSearchBookByPieceTitle = "search/books/{pieceName}";


				$scope.searchByName = function(name) {

					var requestedSearch = searchServiceUrl + restfulSearchBookByPieceTitle.replace("{pieceName}", name);
					$http.get(requestedSearch)
						.success(function(data) {
							$scope.searchResult = data;
						})
						.error(function(data, status, headers, config) {
								$scope.searchResult = config;

								alert("error!");
							}
						);
				}
			}
		])
		.directive('grades', function() {
				return function(scope, el, attrs) {
						el.bind('mousedown', function(e) {
							e.metaKey = true;
						}).selectable();
				}
			});
})();
