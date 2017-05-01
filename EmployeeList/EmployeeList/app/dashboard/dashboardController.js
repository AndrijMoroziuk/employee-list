(function () {
    'use strict';

    function dashboardController() {
        var ctrl = this;

    }

    dashboardController.$inject = [];

    angular.module('employeelist')
        .component('dashboardPage', {
            templateUrl: '/app/dashboard/dashboard.html',
            controller: dashboardController
        });
})()
