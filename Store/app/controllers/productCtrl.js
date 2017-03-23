angular.module("app")
	.controller("productCtrl", function($rootScope, $scope, $stateParams, httpService, cartService) {
		$scope.product = {};

		$scope.cart = cartService;

		// gallery-settings-start
		$scope.gallery = {
			activeImageIndex: 0,
			goGalleryLeft : function() {
				if (this.activeImageIndex) {
					this.activeImageIndex--;
				}
			},
			goGalleryRight: function () {
				if (this.activeImageIndex < $scope.product.images.length-1) {
					this.activeImageIndex++;
				}
			},
			setActiveIndex: function (newIndex) {
				if (0 <= newIndex <= $scope.product.images.length - 1) {
					this.activeImageIndex = newIndex;
				}
			}
		}
		// gallery-settings-end

		$scope.addToCart = function() {
			cartService.changeProductCount($scope.product);
		}

		function init() {
			var productName = $stateParams.name;
			httpService.productsApi.get({
				name: productName
			}).$promise.then(
			function (result) {
				$scope.product = result;
			},
			function (result) {

			});
		}

		init();
	})