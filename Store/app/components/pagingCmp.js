var pagingCmp = angular.module("pagingCmp", []);

var pagingServiceFunc = function ($q, $rootScope) {
	var service = {
		// service configuration
		configuration: {
			pagingTemplateUrl: "",
			pagingInfoResource: {},
			pagingOptions: {}
		},
		pages: [],
		info: {
			currentPage: -1,
			totalPages: -1,
			totalItemsCount: -1
		},
		search: {
			searchString: "",
			ascDescFilter: "",
			filterTags: []
		},
		goToPage : goToPage
	}

	function isPageLoaded(pageNumber) {
		return service.pages[pageNumber];
	}

	function loadNewPage(pageNumber) {
		var queryArgs = {
			pageSize: service.configuration.pagingOptions.itemsPerPage,
			pageNumber: pageNumber,
			searchString: service.search.searchString,
			filterTagNames: service.search.filterTags.map(function (tag) { return tag.name; }).join("|") || "",
			orderBy: service.search.ascDescFilter || "",
			minPrice: service.search.minPrice || "",
			maxPrice: service.search.maxPrice || ""
	};

		return service.configuration.pagingInfoResource.query(queryArgs).$promise.then(
			// success
			function (result) {
				var newPage = {
					contents: []
				};
				result.contents.forEach(function (content) {
					newPage.contents.push(content);
				});

				service.pages[pageNumber] = newPage;

				// in case this is the first page loaded
				if (service.info.totalPages < 1) {
					service.info.totalPages = result.totalPages;
				}
				if (service.info.totalItemsCount < 1) {
					service.info.totalItemsCount = result.totalCount;
				}

				return result.$promise;
			},
			// fail
			function (result) {
				return $q.reject(result);
			});
	}

	function goToPage(pageNumber) {
		var deferedResult = $q.defer();

		if (( (service.info.totalPages > 0) && (pageNumber > service.info.totalPages) ) || (pageNumber < 1)) {
			return deferedResult.reject(
			{
				error: "Page number is out of range"
			});
		}

		if (isPageLoaded(pageNumber)) {
			service.info.currentPage = pageNumber;
			deferedResult.resolve();
		}
		else {
			return loadNewPage(pageNumber).then(function() {
				service.info.currentPage = pageNumber;
			});
		}
		return deferedResult.promise;
	}
	function resetPaging() {
		service.pages = [];
		service.info.currentPage = -1;
		service.info.totalItemsCount = -1;
		service.info.totalPages = -1;
	}

	function init() {
		$rootScope.$watch(function() {
			return service.search.searchString;
		}, function () {
			resetPaging();
			goToPage(1);
		});

		$rootScope.$watch(function() {
			return service.search.filterTags.length;
		}, function() {
			resetPaging();
			goToPage(1);
		});

		$rootScope.$watch(function () {
			return service.search.searchString;
		}, function () {
			resetPaging();
			goToPage(1);
		});

		$rootScope.$watch(function () {
			return service.search.ascDescFilter;
		}, function () {
			resetPaging();
			goToPage(1);
		});

		$rootScope.$watch(function () {
			return service.search.minPrice;
		}, function () {
			resetPaging();
			goToPage(1);
		});

		$rootScope.$watch(function () {
			return service.search.maxPrice;
		}, function () {
			resetPaging();
			goToPage(1);
		});
	}

	init();

	return service;
};

pagingCmp.factory("pagingService", pagingServiceFunc);

pagingCmp.directive("pagingBar", function(pagingService) {
	return {
		restrict: "E",
		templateUrl: pagingService.configuration.pagingTemplateUrl,
		controller: function ($scope, pagingService) {
			// for creating an different page numbers
			$scope.Array = Array;

			$scope.info = pagingService.info;
			$scope.goToPage = function(newPage) {
				pagingService.goToPage(newPage);
			};
		}
	}
});