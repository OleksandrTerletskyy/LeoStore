angular.module("app")
.run(function (pagingService, httpService) {
		var confObj = pagingService.configuration;
		confObj.pagingTemplateUrl = "app/views/paging/paging.html";
		confObj.pagingInfoResource = httpService.productsApi;
		confObj.pagingOptions = {
			itemsPerPage: 10
		}
	})