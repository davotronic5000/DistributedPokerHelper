(function () {

    'use strict';

    angular
        .module('app')
        .config(config);

    config.$inject = [
        '$routeProvider'
    ];

    function config($routeProvider) {
        $routeProvider.when('/',
            {
                redirectTo: '/Timer'
            });
    }

})();