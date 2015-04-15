(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('LoginCtrl', LoginCtrl);

    function LoginCtrl($scope, $state,$ionicHistory, restSvc) {
        this.scope = $scope;
        this.state = $state;
        this.ionicHistory = $ionicHistory;
        this.restSvc = restSvc;
        this._init();
    }

    LoginCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this._registerMethod();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.goback = function() {
                _this.ionicHistory.goBack();
            }
        }
    }
})();
