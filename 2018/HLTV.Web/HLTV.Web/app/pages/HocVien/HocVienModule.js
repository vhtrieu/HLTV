(function () {
    'use strict';

    angular.module('BlurAdmin.pages.HocVien', [])
        .config(routeConfig);

    /** @ngInject */
    function routeConfig($stateProvider) {
        $stateProvider
            .state('HocVien', {
                url: '/tra-cuu-hoc-vien',
                parent: 'base',
                controller: 'HocVienController',
                templateUrl: 'app/pages/HocVien/HocVien.html',
                title: 'Tra cứu học viên',
                sidebarMeta: {
                    icon: 'ion-android-boat',
                    order: 800,
                },
            });
    }

})();