(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData', 'apiService',
    function ($http, $q, authenticationService, authData, apiService) {
        var userInfo;
        var deferred;
        this.login = function (userName, password) {
            deferred = $q.defer();
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post('/Token', data, {
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                userInfo = {
                    accessToken: response.data.access_token,
                    userName: userName,
                };
                
                authenticationService.setTokenInfo(userInfo);
                authData.authenticationData.IsAuthenticated = true;
                authData.authenticationData.userName = userName;
                authData.authenticationData.accessToken = userInfo.accessToken;
                deferred.resolve(null);
            }, function (err, status) {
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.accessToken = "";
                deferred.resolve(err);
            })
            return deferred.promise;
        }

        this.logOut = function () {
            authenticationService.removeToken();

            apiService.post('/api/account/logout', null, function (response) {
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                authData.authenticationData.accessToken = "";
            }, null);

        }
    }]);
})(angular.module('BlurAdmin.common'));