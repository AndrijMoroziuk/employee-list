(function () {
    'use strict';

    function employeeService($http) {
        var factory = this;

        factory.getEmployeeList = function (skip) {
            return $http.get("/api/employeelist", { params: { skip: skip } });
        }

        factory.createEmployee = function (employee) {
            return $http.post("/api/employee", employee);
        }

        factory.deleteEmployee = function (id) {
            return $http.delete("/api/employee", { params: { id: id } });
        }

        return factory;
    };

    employeeService.$inject = ['$http'];

    angular
      .module('employee.service', [])
      .service('employeeService', employeeService);

})();