(function(angular) {
	angular
		.module("app")
		.config(function($stateProvider, $urlRouterProvider) {
			var states = [
				{
					name: "home",
					url: "",
					controller: "homeCtrl",
					templateUrl: "app/views/home/home.html"
				},
				{
					name: "product",
					url: "/product/{name}",
					controller: "productCtrl",
					templateUrl : "app/views/product/product.html"
				}
			];
			states.forEach(function (state) {
				$stateProvider.state(state);
			});
		});
})(angular);