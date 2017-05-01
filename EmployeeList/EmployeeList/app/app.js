/* App Module */
angular.module('employeelist', [
    'ui.router',
    'ui.bootstrap',
    'el.error',
    'el.access',
    'el.loading',
    'el.dashboard',
    'account.service',
    'authorization.service',
    'currentUser.service',
    'employee.service',
    'ngMessages',
    'interceptorRequestError',
    'toastr',
    'LocalStorageModule'
])
    .config(['$sceDelegateProvider', '$urlRouterProvider', '$locationProvider', '$httpProvider', 'toastrConfig', '$stateProvider',
        function ($sceDelegateProvider, $urlRouterProvider, $locationProvider, $httpProvider, toastrConfig, $stateProvider) {

            angular.extend(toastrConfig, {
                allowHtml: true,
                newestOnTop: true,
                progressBar: true,
                positionClass: 'toast-bottom-left',
                preventOpenDuplicates: true
            });

            $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';

            $locationProvider.html5Mode({
                enabled: true,
                requireBase: false
            });

            $urlRouterProvider.otherwise("/error/notfound");

            $sceDelegateProvider.resourceUrlWhitelist([
                'self',
                'https://test.blob.core.windows.net/**'
            ]);
        }])
    .run(['$http', '$rootScope', 'localStorageService', 'currentUserService', function ($http, $rootScope, localStorageService, currentUserService) {
        var userInfo = localStorageService.get('currentUser');
        if (userInfo && new Date(userInfo.expires) > new Date()) {
            angular.extend(currentUserService, userInfo);
            $http.defaults.headers.common.Authorization = userInfo.token;

            console.log("currentUser", userInfo);
        }
        $rootScope.isAuthenticated = currentUserService.isAuthenticated()
    }]);
