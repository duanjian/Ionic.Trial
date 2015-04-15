(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('InfoCommentCtrl', InfoCommentCtrl);

    function InfoCommentCtrl($scope, $state, $ionicHistory, $ionicNavBarDelegate, restSvc) {
        this.scope = $scope;
        this.state = $state;
        this.ionicHistory = $ionicHistory;
        this.ionicNavBarDelegate = $ionicNavBarDelegate;
        this.restSvc = restSvc;
        this._init();
    }

    InfoCommentCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.comments = [];
            _this._registerMethod();
            _this.scope.getCommentById();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.getCommentById = function() {
                    _this.restSvc.get({
                        controller: 'Info',
                        action: 'Comments',
                        id: _this.state.params.id,
                        pageIndex: 1,
                        pageSize: 10
                    }, function(res) {
                        if(res.Result == 1 && res.Data.length > 0)
                        {
                            var comment = res.Data[0].InfoList;
                            _this.scope.comments = comment;
                        }
                    }, function(res) {

                    });
                },
                _this.scope.goBack = function() {
                    _this.ionicHistory.goBack();
                    //_this.ionicNavBarDelegate.back();
                    // alert(_this.ionicHistory.viewHistory())
                }
        }
    }

})();
