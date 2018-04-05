/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.factory('commonService', commonService);


    function commonService() {
        return {          
            getTree: getTree
        }      
        function getTree(list, primaryIdName, parentIdName) {
            var map = {}, node, roots = [], i;
            for (i = 0; i < list.length; i += 1) {
                map[list[i][primaryIdName]] = i; // initialize the map
                list[i].children = []; // initialize the children
            }
            for (i = 0; i < list.length; i += 1) {
                node = list[i];
                if (node[parentIdName] !== null && list[i][primaryIdName] !== 0) {
                    // if you have dangling branches check that map[node.parentId] exists
                    list[map[node[parentIdName]]].children.push(node);
                } else {
                    roots.push(node);
                }
            }
            return roots;
        }
    }
})(angular.module('BlurAdmin.common'));