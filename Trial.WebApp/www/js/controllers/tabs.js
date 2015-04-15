(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('TabsCtrl', TabsCtrl);


    function TabsCtrl($scope, $state, $rootScope, restSvc) {
        this.rootScope = $rootScope;
        this.scope = $scope;
        this.state = $state;
        this.restSvc = restSvc;
        this._init();
    }

    TabsCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.categories = [];
            _this._registerMethod();
            _this.scope.enableCategoryMenu = false;
            if (_this.scope.categories.length <= 0){
                _this.scope.getCategory();                
            }
        },
        _registerMethod: function() {
            var _this = this;
            _this.rootScope.$on('hideTabs', function(event, data) {
                _this.scope.hideTabs = data;
            });
            _this.rootScope.$on('enableCategoryMenu', function(event, data) {
                _this.scope.enableCategoryMenu = data;
            });

            _this.scope.getCategory = function() {
                _this.restSvc.get({
                    controller: 'Course',
                    action: 'Category'
                }, function(res) {
                    if (res.Result == 1) {
                        _this.scope.categories = res.Data;
                    }
                }, function(res) {

                });
            }
        }
    }
})();
