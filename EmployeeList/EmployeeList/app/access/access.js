(function () {
    angular.module('el.access', [])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                    .state('signin', {
                        url: "/?returnUrl",
                        template: '<signin-page></signin-page>',
                        data: {
                            pageTitle: 'Sign in'
                        },
                        resolve: {
                            authorize: ['authorizationService', function (authorizationService) {
                                return authorizationService.authorize();
                            }]
                        }
                    })
        }])
        .run(['$rootScope', '$state', '$stateParams', 'currentUserService', function ($rootScope, $state, $stateParams, currentUserService) {
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            $rootScope.$on('$stateChangeStart', function (e, toState, toParams, fromState, fromParams) {
                var isSignIn = toState.name === "signin";
                var noLogin = false;

                if (toState.data != null) {
                    if (toState.data.noLogin)
                        noLogin = toState.data.noLogin;
                }

                if (noLogin || isSignIn) {
                    return; // no need to redirect 
                }

                var authenticated = currentUserService.isAuthenticated();

                if (authenticated === false) {
                    e.preventDefault(); // stop current execution
                    $state.go('signin', {}, { reload: true }); // go to login
                }
            });
        }]);
})();