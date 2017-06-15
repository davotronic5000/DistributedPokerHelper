(function () {

    'use strict';

    angular
        .module('app.blindTimer')
        .controller('app.blindTimer.blindTimerController', blindTimerController);

    blindTimerController.$inject = [
        'app.services.blindTimerHubService'
    ];

    function blindTimerController(blindTimerHub) {
        var vm = this;
        vm.blindTimerHub = blindTimerHub;
    }

})();