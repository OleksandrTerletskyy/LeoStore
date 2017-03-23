var cart = angular.module("cartCmp", []);

cart.provider("cartService", function () {
	// cart data
	var cartData = [];

	// service configuration data
	var cartTemplateUrl = "";

	return {
		setTemplateUrl: function(url) {
			cartTemplateUrl = url;
			return this;
		},

		// returns service interface
		$get: function () {
			var removeProduct = function(id) {
				for (var i = 0; i < cartData.length; i++) {
					if (cartData[i].product.id === id) {
						cartData.splice(i, 1);
						break;
					}
				}
			}
			return {
				changeProductCount: function(product, quantityDifference) {
					if (quantityDifference === 0) {
						return;
					}
					for (var i = 0; i < cartData.length; i++) {
						if (cartData[i].product.id === product.id) {
							if (!quantityDifference) {
								cartData[i].count++;
								return;
							}
							if (quantityDifference > 0) {
								cartData[i].count += quantityDifference;
								return;
							}
							if (-quantityDifference === cartData[i].count) {
								removeProduct(cartData[i].product.id);
								return;
							}
							if (-quantityDifference > cartData[i].count) {
								return;
							}
							cartData[i].count += quantityDifference;
							return;
						}
					}
					if (quantityDifference < 0) {
						return;
					}
					cartData.push({
						count: quantityDifference || 1,
						product: product
					});
				},
				removeProduct: removeProduct,
				cartData: cartData,
				cartTemplateUrl: cartTemplateUrl
			}
		}
	};
});

cart.directive("smallCart", function (cartService) {
	return {
		restrict: "EA",
		templateUrl: cartService.cartTemplateUrl,
		controller: function ($scope) {
			$scope.cartItems = [];
			$scope.total = 0;

			var recalc = function () {
				$scope.total = 0;
				for (var i = 0; i < $scope.cartItems.length; i++) {
					$scope.total += ($scope.cartItems[i].product.price * $scope.cartItems[i].count);
				}
			}

			function init() {
				$scope.cartItems = cartService.cartData;
				$scope.$watch("cartItems", recalc, true);
			}

			init();
		}
	}
})