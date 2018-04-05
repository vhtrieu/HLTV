/**
 * @author v.lugovsky
 * created on 16.12.2015
 */
(function () {
    'use strict';

    angular.module('BlurAdmin.pages.partno')
        .directive('modalDialog', function () {
            return {
                restrict: 'AC',
                link: function ($scope, element) {
                    var draggableStr = "draggableModal";
                    var header = $(".modal-header", element);
                    header.on('mousedown', function (mouseDownEvent) {
                        var modalDialog = element;
                        var offset = header.offset();

                        modalDialog.addClass(draggableStr).parents().on('mousemove', function (mouseMoveEvent) {
                            $("." + draggableStr, modalDialog.parents()).offset({
                                top: mouseMoveEvent.pageY - (mouseDownEvent.pageY - offset.top),
                                left: mouseMoveEvent.pageX - (mouseDownEvent.pageX - offset.left)
                            });
                        }).on('mouseup', function (e) {
                            modalDialog.removeClass(draggableStr);
                        });
                    });
                }
            }
        })
        .controller('HocVienController', HocVienController);

    /** @ngInject */
    function HocVienController($scope, apiService, $injector, $location, $uibModal, svgService, $rootScope, notificationService, authData, $translate) {
        $scope.model = {
            SearchText: ""
        }
        $scope.searchType = $location.search().search_type;
        $scope.ViewSearch = true;
        $scope.isLoading = true;
        $scope.loadData = function () {
            $scope.loadDataASSB($scope.model.SearchText);
            $scope.listData = [];
            $scope.listDataASSB = [];
            $scope.ViewSearch = true;
            apiService.get("api/Component?COM_CODE=" + $scope.model.COM_CODE, '', function (res) {
                $scope.listData = res.data;
            }, function (err) { });
        }

        // $scope.loadData();

        $scope.open = function (page, size) {
            var modalinstance = $uibModal.open({
                scope: $scope,
                templateUrl: page,
                // controller: 'PartnoCtrl',
                size: size,
                resolve: {
                    obj: function () {
                        return $scope.listDataPackageBom;
                    },
                    COM_CODE: function () {
                        return $scope.COM_CODE;
                    }
                }
            });
        }
        $scope.loadItem = function (item) {
            apiService.get("/api/PackageBom?COM_ID=" + item.COM_ID, '', function (res) {
                $scope.listDataPackageBom = res.data;
                $scope.COM_CODE = item.COM_CODE;
                $scope.open('app/pages/partno/modal.html', 'lg');
            }, function (err) { });
        }

        $scope.loadDetailPackageBom = function (item) {
            $scope.detailData = [];
            $scope.isLoading = true;
            $scope.ViewSearch = false;
            apiService.get("/api/PackageBom?PAB_PAGID=" + item.PAB_PAGID, '', function (res) {

                $scope.listDataDetail = res.data;

                document.getElementById("svg1").data = "../" + $scope.listDataDetail[0].IMG;
                // $scope.highlightRow($scope.COM_CODE);

                // highlight item svg
                var a = document.getElementById("svg1");
                a.addEventListener("load", function (evt) {
                    $scope.isLoading = false;
                    svgService.highlightItemSVG($scope.COM_CODE);

                    var pos = $scope.listDataDetail.map(function (x) { return x.COM_CODE; }).indexOf($scope.COM_CODE);
                    $scope.loadDetail($scope.listDataDetail[pos]);

                });
            }, function (err) { });
        }

        $scope.highlightRow = function (COM_CODE) {
            // Reset highlight row table
            for (var i = 0; i < $scope.listDataDetail.length; i++) {
                $scope.listDataDetail[i].IsSelected = false;
            }

            // Highlight item se
            var pos = $scope.listDataDetail.map(function (x) { return x.COM_CODE; }).indexOf(COM_CODE);
            $scope.listDataDetail[pos].IsSelected = true;
        }

        $scope.loadDetail = function (item) {
            $scope.highlightRow(item.COM_CODE);
            svgService.highlightItemSVG(item.COM_CODE);
            apiService.get('api/PackageBom?PAB_ID=' + item.PAB_ID + '&USER_ID=' + authData.authenticationData.Id + '&LST=true&DT=true', '', function (res) {
                $scope.detailData = res.data;
            }, function (err) { });
        }

        $scope.zoomOut = function () {
            svgService.zoomOut();
        }

        $scope.zoomIn = function () {
            svgService.zoomIn();
        }


        $scope.model = {
            COM_CODE_PNC: ""
        }
        $scope.loadDataPNC = function () {
            $scope.listDataASSB = [];
            $scope.listDataPNC = [];
            $scope.loadDataASSB($scope.model.COM_CODE_PNC);
            apiService.get("api/Component/Group?COM_CODE=" + $scope.model.COM_CODE_PNC + "&PARENT=true", '', function (res) {
                $scope.listDataPNC = res.data;
            }, function (err) { });
        }

        $scope.$watch(function () { return $location.search() }, function (params) {
            // Reset old data
            $("#svg1").css('width', '800px');
            $scope.isLoading = true;
            $scope.model.COM_CODE = "";
            $scope.model.COM_CODE_PNC = "";
            $scope.listData = [];
            $scope.listDataPNC = [];
            $scope.listDataASSB = [];
            $scope.searchType = $location.search().search_type;
            $scope.ViewSearch = true;
        });

        $scope.showPopupNotePackage = function (item) {
            $scope.itemPackage = {
                USER_ID: authData.authenticationData.Id,
                PAB_ID: item.PAB_ID,
                COM_CODE: item.COM_CODE,
                COM_NAME: item.COM_NAME,
                NOTE: ''
            }
            $("#modalMemoryPackageBom").modal({ backdrop: 'static', keyboard: false });
        }

        $scope.savePackageBom = function () {
            apiService.post('api/UserPackageBom/SavePackageBom', $scope.itemPackage, function (res) {
                if ($translate.use() === 'vn')
                    notificationService.displaySuccess('Lưu thành công.');
                else
                    notificationService.displaySuccess('Save successfully.');
            }, function (err) { });
        }

        $scope.loadDataASSB = function (COM_CODE) {
            apiService.get("api/PackagePosition?PAG_CODE=" + COM_CODE, '', function (res) {
                $scope.listDataASSB = res.data;
            }, function (err) {
            });
        }

        $scope.loadItemASSB = function (item) {
            var stateService = $injector.get('$state');
            window.location.replace("#/tra-cuu-thong-tin-cum-vi-tri1?PAG_CODE=" + item.PAG_CODE + "&VEB_VEHID=" + item.VEB_VEHID);
        }

        $scope.closeModalMemoryPackageBom = function () {
            var pos = $scope.detailData.map(function (x) { return x.PAB_ID; }).indexOf($scope.itemPackage.PAB_ID);
            if (pos >= 0)
                $scope.detailData[pos].IS_MEMORY = false;
            $("#modalMemoryPackageBom").modal('hide');
        }
    }
})();