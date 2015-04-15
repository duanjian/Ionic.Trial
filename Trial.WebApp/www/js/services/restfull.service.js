(function() {
    'use strict';

    angular
        .module('Trial.restfull', ['ngResource'])
        .factory('restSvc', function($resource) {
            return $resource('http://192.168.16.155:8222/api/:controller/:action/:id', {
                controller: '@controller',
                action: '@action',
                id: '@id'
            }, {
                get: {
                    method: 'get'
                },
                post: {
                    method: 'post'
                },
                delete: {
                    method: 'delete'
                },
                put: {
                    method: 'put'
                }
            });
        });
})();
