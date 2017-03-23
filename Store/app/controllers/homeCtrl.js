angular.module("app")
	.constant("productsUrl","/api/products")
	.controller("homeCtrl", function($scope, httpService,cartService, pagingService) {
		$scope.errors = [];

		// cart-start
		$scope.cart = cartService;
		// cart-end

		// tags-start
		$scope.filterTags = [];
		$scope.awailableTags = [];

		$scope.addFilterTag = function (tagId) {
			var tagObj = $scope.awailableTags.find(x => x.id == tagId);
			if (tagObj === undefined) {
				return;
			}
			$scope.filterTags.push(tagObj);
			$scope.awailableTags.splice($scope.awailableTags.indexOf(tagObj), 1);
		}

		$scope.removeFilterTag = function(tag) {
			$scope.filterTags.splice($scope.filterTags.indexOf(tag), 1);
			$scope.awailableTags.push(tag);
		}
		// tags-end

		// navigation-start
		$scope.pages = function () { return pagingService.pages;}
		$scope.info = pagingService.info;
		$scope.goToPage = pagingService.goToPage;
		// navigation-end

		// searching-start
		$scope.searchString = "";
		$scope.ascDescFilter = "";
		$scope.setOrdering = function (value) {
			$scope.ascDescFilter = value;
		}
		// searching-end

		// initialization
		function init() {
			// paging-init-start
			$scope.$watch("searchString", function (newSearchString) {
				pagingService.search.searchString = newSearchString;
			});
			$scope.$watch("ascDescFilter", function (newAscDesc) {
				pagingService.search.ascDescFilter = newAscDesc;
			});
			$scope.$watch("minPrice", function (newMinPrice) {
				pagingService.search.minPrice = newMinPrice;
			});
			$scope.$watch("maxPrice", function (newMaxPrice) {
				pagingService.search.maxPrice = newMaxPrice;
			});
			if (pagingService.info.currentPage === -1) {
				$scope.goToPage(1);
			}
			// paging-init-end

			// tags-init-start
			httpService.getTags()
				.then(
					function (response) {
						$scope.awailableTags = response.data;
					},
					function (errorResponse) {
						$scope.errors.add(errorResponse.data);
					});
			pagingService.search.filterTags = $scope.filterTags;
			$scope.$watch("filterTags.length", function() {
				pagingService.goToPage(1);
			});
			// tags-init-end
		}
		init();
	});