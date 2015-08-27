(function() {
	'use strict';

	angular.module('ductia',
		['ngAnimate', 'ui.bootstrap'])
		.factory("searchService", function ($http) {
			function processResult(response) {
				return response.data;
			}

			var searchServiceUrl = "http://localhost:2487/";
			var restfulSearchBookByPieceTitle = "search/books/{pieceName}";
			var fac = {};
			fac.searchByName = function (name, callbackSuccess, callbackError) {
				var request = $http({
					method: "GET",
					url: searchServiceUrl + restfulSearchBookByPieceTitle.replace("{pieceName}", name)
				});
				return request.then(function(data) {
					var processedData = processResult(data);
					if (typeof callbackSuccess !== "undefined") {
						callbackSuccess(processedData);
					}
				}, function() {
					if (typeof callbackError !== "undefined") {
						callbackError("There was an error retrieving your data");
					}
				});
			}
			fac.searchByCriteria = function(eboard, instrument, grades) {
				
			}

			return fac;
		})
		.controller("SearchController", [
			"$scope", "searchService",
			function($scope, searchService) {
				$scope.examBoards = ["ABRSM", "Trinity"];
				$scope.instruments = ["Flute", "Descant Recorder", "Alto Recorder", "Guitar"];
				$scope.grades = [1, 2, 3, 4, 5, 6, 7, 8];
				$scope.selectedGrades = [];
				$scope.searchResult = "";
				$scope.searchByName = function(name) {
					searchService.searchByName(name, function(data) {
							$scope.searchResult = data;
						},
						function(errorMessage) {
							alert(errorMessage);
						});
				};
				$scope.searchByCriteria = function (eboard, instrument, selgrades) {
					 $scope.selectedGrades = $($scope.selectedGrades).sort();
					alert(JSON.stringify($scope.selectedGrades));
				};
			}
		])
		.directive('ductiaGrades', function() {
				function link(scope, el, attrs) {

					var rootScope = scope.$parent.$parent;

					el.bind('mousedown', function (e) {
						e.metaKey = true;
					}).selectable({
						selected: function(event, ui) {
							rootScope.selectedGrades.push($(ui.selected).text().trim());
						},
						unselected: function(event, ui) {
							var unselectedValue = $(ui.unselected).text().trim();
							var newSelection = $.grep(rootScope.selectedGrades, function (value) {
								return value.trim() !== unselectedValue;
							});
							rootScope.selectedGrades = newSelection;

						}
					});
				}

			return {
				link: link
			};
		});
})();