var ipsumsApp = angular.module('ipsumsApp', []);

ipsumsApp.controller('LoremLewisCtrl', function (LoremLewisSvc) {
    var ctrl = this;
    ctrl.vm = {
        quotes: []
    };
    ctrl.getQuotes = function () {
        return LoremLewisSvc.getQuotes().success(function (results) {
            ctrl.vm.quotes = results;
        });
    };
});


ipsumsApp.factory('LoremLewisSvc', function ($http) {
    return {
        getQuotes: function () {
            return $http.get('/api/ipsums/getlewisquotes', { params: { } });
        }
    };
});