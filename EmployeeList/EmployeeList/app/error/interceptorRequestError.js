(function () {
    'use strict';

    function interceptorError($q, $injector) {
        var interceptor = {
            responseError: function (response) {
                console.log(response);
                var toastr = $injector.get('toastr');

                if (response.status == 500 || response.status == 502) {
                    toastr.error("url: \"" + response.config.url + "\" <br> Contact please administrator", 'Server error');
                }
                else if (response.status == 429) {

                }
                else if (response.status == 400) {
                    toastr.error("url: \"" + response.config.url + "\"", 'Bad request');
                }
                else if (response.status == 401) {
                    toastr.error("Authorization has been denied for this request.");
                }
                else if (response.status == 403) {
                    toastr.error("Access denied.");
                }

                // TODO: was bug 
                //return response;
                return $q.reject(response);
            }
        };
        return interceptor;
    };

    function config($httpProvider) {
        $httpProvider.interceptors.push('interceptorError');
    }

    interceptorError.$inject = ['$q', '$injector'];
    config.$inject = ['$httpProvider'];

    angular
      .module('interceptorRequestError', [])
        .config(config)
        .factory('interceptorError', interceptorError);

})();