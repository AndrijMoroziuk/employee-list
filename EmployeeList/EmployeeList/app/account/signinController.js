(function () {
    'use strict';

    function homeController($state, accountService) {
        var ctrl = this;


        ctrl.register = function (model) {
            console.log(model);
            accountService.signUp(model)
              .success(function (data) {
                  $state.go("signin");
              })
              .error(function (errors) {
               
              });
        }

        ctrl.login = function (model) {
            ctrl.signInInfo = { grant_type: 'password' };
            ctrl.signInInfo.username = model.email;
            ctrl.signInInfo.password = model.password;

            accountService.signIn($.param(ctrl.signInInfo)).then(function () {
                $state.go('employeeList');
            }).catch(function () {
                console.log("error login");
            });
        }

    }

    homeController.$inject = ['$state', 'accountService'];

    angular.module('employeelist')
        .component('signinPage', {
            templateUrl: '/app/account/signin.html',
            controller: homeController
        })
})()
