(function(angular) {

	function httpService($http, $resource) {
		function getProducts() {
			var promise = $http.get("/api/products");
			return promise;
		}

		function getTags() {
			var promise = $http.get("/api/tags");
			return promise;
		}

		var productsApi = $resource("api/products/:id",
				{
					id: "@id"
				},
				{
					'query': {
						method: "GET",
						params:
						{
							pageSize: "@pageSize",
							pageNumber: "@pageNumber",
							searchString: "@searchString",
							filterTagNames: "@filterTagNames",
							orderBy: "@orderBy",
							minPrice: "@minPrice",
							maxPrice: "@maxPrice"
						},
						url: "/api/products/:pageSize/:pageNumber"

					},
					"get" : {
						method: "GET",
						url: "/api/products/:name",
						params: {name:"@name"}
					}
				});
	
		return {
			getProducts : getProducts,
			getTags: getTags,
			productsApi: productsApi
		}
	}

	angular
		.module("app")
		.factory("httpService", httpService);

	httpService.$inject = ["$http","$resource"];
})(angular);



