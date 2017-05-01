(function () {
    'use strict';

    function confirmDeleteController() {
        var ctrl = this;
        
        ctrl.confirm = function (yesOrNo) {
            ctrl.close({ $value: yesOrNo });
        }
    }
    confirmDeleteController.$inject = [];

    angular.module('employeelist')
        .component('confirmDelete', {
            templateUrl: '/app/modalComponents/confirmDelete.html',
            controller: confirmDeleteController,
            bindings: {
                close: '&',
                dismiss: '&'
            }
        });
})()
