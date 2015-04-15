(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('InfoDetailsCtrl', InfoDetailsCtrl);

    function InfoDetailsCtrl($scope, $rootScope, $state, $ionicActionSheet, $ionicHistory, $ionicLoading, restSvc) {
        this.scope = $scope;
        this.rootScope = $rootScope;
        this.state = $state;
        this.ionicLoading = $ionicLoading;
        this.ionicActionSheet = $ionicActionSheet;
        this.ionicHistory = $ionicHistory;
        this.restSvc = restSvc;
        this._init();
    }

    InfoDetailsCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.info = {};            
            _this.scope.info.ImageUrl = 'img/resource-cordova.png';
            _this._registerMethod();
            _this.scope.getInfoById();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.getInfoById = function() {
                    _this.ionicLoading.show();
                    _this.restSvc.get({
                        controller: 'Info',
                        action: 'GetInfoById',
                        id: _this.state.params.id
                    }, function(res) {
                        if (res.Result == 1) {
                            var info = res.Data[0];
                            var index = info.ShareContent.indexOf('h');
                            //document.querySelector('#divContent').innerHTML = info.Content;
                            _this.scope.info = {
                                Id: _this.state.params.id,
                                Title: info.ShareContent.substring(0, index),
                                Content: info.Content,
                                ImageUrl: info.Image,
                                Hits: info.Hits,
                                Date: _this.state.params.date
                            };
                            _this.ionicLoading.hide();
                        }
                    }, function(res) {

                    });
                },
                _this.scope.goBack = function() {
                    _this.rootScope.$emit('hideTabs', false);
                    _this.ionicHistory.goBack();
                    //_this.state.go('tabs.info');
                }
        }
    }
})();
