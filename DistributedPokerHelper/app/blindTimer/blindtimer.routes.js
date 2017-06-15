(function () {

    'use strict';

    angular
        .module('app.blindTimer')
        .config(config);

    config.$inject = [
        '$routeProvider'
    ];

    function config($routeProvider) {
        $routeProvider.when('/Timer',
            {
                controller: 'app.blindTimer.blindTimerController',
                templateUrl: '/app/blindTimer/blindtimer.html',
                controllerAs: 'vm'
            });
    }

})();