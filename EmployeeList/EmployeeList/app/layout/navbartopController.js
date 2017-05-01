(function () {
    'use strict';

    function navbartopController($state, accountService, currentUserService) {
        var ctrl = this;
        ctrl.currentUserService = currentUserService;

        ctrl.logOut = function () {
            accountService.logOut();
        }

    }

    navbartopController.$inject = ['$state', 'accountService', 'currentUserService'];

    angular.module('employeelist')
        .component('navBarTop', {
            templateUrl: '/app/layout/navbartop.html',
            controller: navbartopController
        });
})()
