(function () {
    'use strict';

    function currentUserService($http, $timeout, localStorageService) {
        var user = {};

        user.isAuthenticated = function () {
            if (user.token && new Date(user.expires) > new Date())
                return true;
            else
                return false
        }

        user.isInRole = function (role) {
            if (!user.roles)
                return false;

            if (user.roles.indexOf(role) !== -1)
                return true;
            else
                return false;
        }

        user.getRole = function () {
            if (user.roles)
                return user.roles[0];
            else
                return;
        }

        return user;
    };



    currentUserService.$inject = ['$http', '$timeout', 'localStorageService'];

    angular
      .module('currentUser.service', [])
      .factory('currentUserService', currentUserService);

})();



