(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);

    //$state, $stateParams là cái inject trong ui.router
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }


        function loadProductCategoryDetail() {
            //id phải giống với tham số ở apiController
            apiService.get('api/productcategory/getbyid/' + $stateParams.id,null ,function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }



        function UpdateProductCategory() {
            apiService.put('api/productCategory/update', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' cập nhật thành công ');
                    //di chuyển đên trang product category
                    $state.go('product_categories');
                },
                function (error) {
                    notificationService.displayError('cập nhật không thành công');
                });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/getallparents', null,
                function (result) {
                    $scope.parentCategories = result.data;
                }, function () {
                    console.log('cannot get list parent');
                });
        }

        loadParentCategory();
        loadProductCategoryDetail();
    }
    

})(angular.module('tedushop.product_categories'));