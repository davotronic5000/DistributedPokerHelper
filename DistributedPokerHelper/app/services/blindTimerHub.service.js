(function () {

    angular
        .module('app.services')
        .factory('app.services.blindTimerHubService', blindTimerHubService);

    blindTimerHubService.$inject = [
        'Hub',
        '$rootScope'
    ];

    function blindTimerHubService(Hub, $rootScope) {
        var service = {
            totalTimerSeconds: 0,
            totalElapsedSeconds: 0
        }

        var hub = new Hub('blindTimerHub',
            {
                listeners: {
                    getTimerState: getTimerState
                },
                methods: [],
                rootPath: '/api',
                useSharedConnection: false,
                errorHandler: errorHandler
            });

        function getTimerState(totalTimerSeconds, totalElapsedSeconds) {
            service.totalElapsedSeconds = totalElapsedSeconds;
            service.totalTimerSeconds = totalTimerSeconds;
            $rootScope.$apply();
        }


        function errorHandler(error) {
            console.error(error);
        }

        return service;
        }

})();