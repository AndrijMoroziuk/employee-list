(function () {
    'use strict';

    function accountService($http, $rootScope, $state, localStorageService, toastr, currentUserService) {
        var factory = this;

        factory.signUp = function (model) {
            return $http.post("/api/account/register", model)
                .success(function () {
                    toastr.success("Successfully registered, please login");
                }).error(function (data) {
                    toastr.error(data.message);
                });
        }

        factory.signIn = function (model) {
            return $http.post("/api/token", model)
                .success(function (data) {
                    if (!data)
                        return;

                    var currentUser = {};

                    if (data && data.roles && !Array.isArray(data.roles))
                        currentUser.roles = JSON.parse(data.roles);

                    if (data && data['.expires'])
                        currentUser.expires = new Date(data['.expires']);

                    currentUser.token = data.token_type + " " + data.access_token;
                    currentUser.userName = data.userName;

                    angular.extend(currentUserService, currentUser);

                    localStorageService.set('currentUser', currentUser);
                    $http.defaults.headers.common.Authorization = currentUser.token;

                    $rootScope.isAuthenticated = true;
                });
        }

        factory.logOut = function (model) {
            return $http.post("/api/account/logout", model)
                .success(function () {
                    localStorageService.remove('currentUser');
                    delete $http.defaults.headers.common.Authorization;
                    delete currentUserService.token;
                    $state.go("signin", {}, { reload: true });

                    $rootScope.isAuthenticated = false;
                });
        }
    };

    accountService.$inject = ['$http', '$rootScope', '$state', 'localStorageService', 'toastr', 'currentUserService'];

    angular
      .module('account.service', [])
      .service('accountService', accountService);

})();