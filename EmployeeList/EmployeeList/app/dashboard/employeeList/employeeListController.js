(function () {
    'use strict';

    function employeeListController(employeeService, $uibModal, toastr) {
        var ctrl = this;

        employeeService.getEmployeeList().success(function (data) {
            ctrl.employeeList = data;
        });

        ctrl.deleteEmployee = function (id) {
            var modalInstance = $uibModal.open({
                animation: true,
                component: 'confirmDelete'
            });

            modalInstance.result.then(function (result) {
                if (result) {
                    employeeService.deleteEmployee(id).success(function (data) {
                        if (data.success) {
                            angular.forEach(ctrl.employeeList, function (item, index) {
                                if (item.id == id) {
                                    ctrl.employeeList.splice(index, 1);
                                    toastr.success("Successfully deleted.");
                                    return;
                                }
                            });
                        } else {
                            toastr.error(data.message);
                        }
                    });
                }
            });
        }

    }

    employeeListController.$inject = ['employeeService', '$uibModal', 'toastr'];

    angular.module('employeelist')
        .component('employeeListPage', {
            templateUrl: '/app/dashboard/employeeList/employeeList.html',
            controller: employeeListController
        });
})()
