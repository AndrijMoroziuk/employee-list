(function () {
    angular.module('el.dashboard', ['authorization.service'])
        .config(['$stateProvider', function ($stateProvider) {
            //$stateProvider.state('dashboard', {
            //    url: '',
            //    template: '<dashboard-page></dashboard-page>',
            //    abstract: true,
            //    controllerAs: '$ctrl',
            //    controller: ['$state', function ($state) {
            //        this.$state = $state;

            //    }]
            //});

            $stateProvider
                .state('employeeList', {
                    url: "/dashboard",
                    template: '<employee-list-page></employee-list-page>',
                    data: {
                        pageTitle: 'Dashboard'
                    }
                })
                .state('addEmployee', {
                    url: "/addEmployee",
                    template: '<add-employee-page></add-employee-page>',
                    data: {
                        pageTitle: 'Add new employee'
                    }
                })
        }])
})();