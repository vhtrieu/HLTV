(function (app) {
    'use strict';
    app.factory('svgService', [function () {
        return {
            highlightItemSVG: highlightItemSVG,
            zoomIn: zoomIn,
            zoomOut: zoomOut
        }

        function highlightItemSVG(itemCode) {
            var a = document.getElementById("svg1");
            var svgDoc = a.contentDocument;
            // var element = svgDoc.getElementById("hotspot.10");
            // console.log(element);
            var tagG = svgDoc.getElementsByTagName("g");

            var texts = svgDoc.getElementsByTagName("text");
            for (var i = 0; i < texts.length; i++) {

                var t = texts[i];
                t.parentNode.removeAttribute("fill");
                if (t.innerHTML === itemCode) {
                    // console.log("OK", t.parentNode);
                    t.parentNode.setAttribute("fill", "#00ff00");
                    // t.setAttribute("fill", "#FFF");

                }
            };
        }
        
        function zoomIn() {
            var svg = $("#svg1");
            var w = svg.width();
            svg.width(w + 100);
        }

        function zoomOut() {
            var svg = $("#svg1");
            var w = svg.width();
            svg.width(w - 100);
        }
    }]);
})(angular.module('BlurAdmin.common'));
