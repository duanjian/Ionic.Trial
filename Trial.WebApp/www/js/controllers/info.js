(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('InfoCtrl', InfoCtrl);

    function InfoCtrl($scope, restSvc) {
        this.scope = $scope;
        this.restSvc = restSvc;
        this._init();
    }

    InfoCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.infos = [];
            _this.scope.pageIndex = 1;
            _this.scope.pageSize = 10;
            _this.scope.noMoreItemsAvailable = false;
            _this._registerMethod();
            _this.scope.getInfos();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.getInfos = function() {
                    _this.restSvc.get({
                        controller: 'Info',
                        action: 'Get',
                        pageIndex: 1,
                        pageSize: 10
                    }, function(res) {
                        //++_this.scope.pageIndex;
                        if (res.Result == 1) {
                            _this.scope.infos = [];
                            var data = res.Data[0].InfoList;
                            angular.forEach(data, function(value, key) {
                                _this.scope.infos.push(value);
                            })
                        }
                    }, function(res) {

                    });

                    _this.scope.$broadcast('scroll.refreshComplete');
                    _this.scope.$broadcast('scroll.infiniteScrollComplete');
                },
                _this.scope.fetchMore = function() {
                    ++_this.scope.pageIndex;
                    _this.restSvc.get({
                        controller: 'Info',
                        action: 'Get',
                        pageIndex: _this.scope.pageIndex,
                        pageSize: 10
                    }, function(res) {

                        if (_this.scope.infos.length == res.Data[0].InfoCount) {
                            _this.scope.noMoreItemsAvailable = true;
                        }
                        if (res.Result == 1) {
                            var data = res.Data[0].InfoList;
                            angular.forEach(data, function(value, key) {
                                _this.scope.infos.push(value);
                            })

                        }

                    }, function(res) {

                    });

                    _this.scope.$broadcast('scroll.infiniteScrollComplete');
                }
        }
    }
})();
