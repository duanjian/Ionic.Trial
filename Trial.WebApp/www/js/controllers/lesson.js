(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('LessonCtrl', LessonCtrl);

    function LessonCtrl($scope, $rootScope, $state, restSvc) {
        this.scope = $scope;
        this.state = $state;
        this.rootScope = $rootScope;
        this.restSvc = restSvc;
        this._init();
    }

    LessonCtrl.prototype = {
        _init: function() {
            this._setScope();
            this.rootScope.$emit('enableCategoryMenu', true);

        },
        _setScope: function() {
            var _this = this;
            _this.scope.courses = [];
            _this.scope.pageIndex = 1;
            _this.scope.pageSize = 10;
            _this.scope.noMoreItemsAvailable = false;
            _this.scope.cateId = 71107;
            _this.scope.cateId = _this.state.params.cid == 0 ? 71107 : _this.state.params.cid;
            var tmp = _this.state.params.cid;
            _this._registerMethod();
            _this.scope.getCourses();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.getCourses = function() {
                    _this.restSvc.get({
                        controller: 'Course',
                        action: 'Courses',
                        id: _this.scope.cateId,
                        pageIndex: 1,
                        pageSize: _this.scope.pageSize
                    }, function(res) {
                        if (res.Result == 1) {
                            _this.scope.courses = [];
                            var data = res.Data[0].InfoList;
                            angular.forEach(data, function(value, key) {
                                _this.scope.courses.push(value);
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
                        controller: 'Course',
                        action: 'Courses',
                        id: _this.scope.cateId,
                        pageIndex: _this.scope.pageIndex,
                        pageSize: _this.scope.pageSize
                    }, function(res) {
                        if (_this.scope.courses.length == res.Data[0].InfoCount) {
                            _this.scope.noMoreItemsAvailable = true;
                        }
                        if (res.Result == 1) {
                            var data = res.Data[0].InfoList;
                            angular.forEach(data, function(value, key) {
                                _this.scope.courses.push(value);
                            })
                        }

                    }, function(res) {

                    });

                    _this.scope.$broadcast('scroll.infiniteScrollComplete');
                }
        }
    }
})();
