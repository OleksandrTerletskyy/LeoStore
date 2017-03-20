(function(angular) {
	angular
		.module("app")
		.config(function(cartServiceProvider) {
			cartServiceProvider.setTemplateUrl("app/views/cart/smallCart.html");
		});
})(angular);