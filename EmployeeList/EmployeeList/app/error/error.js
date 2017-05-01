(function () {
    angular.module('el.error', ['error.service'])
        .config(['$stateProvider', function ($stateProvider) {
            $stateProvider
                .state('notfound', {
                    url: "/error/notfound",
                    templateUrl: '/error/notfound',
                    data: {
                        pageTitle: 'Page Not Found',
                        noLogin: true
                    }
                })
        }]);
})();