(function () {
    'use strict';

    function addEmployeeController($state, employeeService, toastr) {
        var ctrl = this;
        ctrl.options = {
            maxDate: new Date()
        }

        ctrl.createEmployee = function (form) {
            if (form) {
                employeeService.createEmployee(ctrl.employee).success(function (data) {
                    toastr.success("Successfully created.");
                    $state.go('employeeList');
                });
            }
        }

        ctrl.openCalendar = function () {
            ctrl.isOpenCalendar = true;
        }

    }

    addEmployeeController.$inject = ['$state', 'employeeService', 'toastr'];

    angular.module('employeelist')
        .component('addEmployeePage', {
            templateUrl: '/app/dashboard/addEmployee/addEmployee.html',
            controller: addEmployeeController
        });
})()
