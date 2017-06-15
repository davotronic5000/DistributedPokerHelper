(function () {

    'use strict';

    angular
        .module('app.core',
            [
                'ngRoute',
                'ngSanitize',
                'ui.bootstrap',
                'ngCookies',
                'SignalR'
            ]);

})();