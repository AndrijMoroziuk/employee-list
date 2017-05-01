(function () {
    'use strict';

    function authorizationService($q, $state, $timeout, currentUserService) {
        return {
            authorize: function (stateName) {
                var isAuthenticated = currentUserService.isAuthenticated();
                var defer = $q.defer();
                if (isAuthenticated) {
                    $timeout(function () {
                        $state.go('employeeList');
                    });

                    defer.reject(); /* (1) */
                } else {
                    defer.resolve(); /* (2) */
                }

                return defer.promise;
            }
        };
    }



    authorizationService.$inject = ['$q', '$state', '$timeout', 'currentUserService'];

    angular
      .module('authorization.service', [])
      .factory('authorizationService', authorizationService);

})();



