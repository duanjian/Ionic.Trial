(function() {
    'use strict';

    angular
        .module('Trial')
        .controller('LessonDetailsCtrl', LessonDetailsCtrl);


    function LessonDetailsCtrl($scope, $state, $rootScope, $ionicActionSheet, $ionicHistory, restSvc) {
        this.scope = $scope;
        this.state = $state;
        this.rootScope = $rootScope;
        this.ionicActionSheet = $ionicActionSheet;
        this.ionicHistory = $ionicHistory;
        this.restSvc = restSvc;
        this._init();
    }

    LessonDetailsCtrl.prototype = {
        _init: function() {
            this._setScope();
        },
        _setScope: function() {
            var _this = this;
            _this.scope.course = {};
            _this._registerMethod();


            // _this.scope.tabs = [{
            //     title: 'Home',
            //     content: 'Raw denim you probably haven\'t heard of them jean shorts Austin. Nesciunt tofu stumptown aliqua, retro synth master cleanse. Mustache cliche tempor, williamsburg carles vegan helvetica.'
            // }, {
            //     title: 'Profile',
            //     content: 'Food truck fixie locavore, accusamus mcsweeney\'s marfa nulla single-origin coffee squid. Exercitation +1 labore velit, blog sartorial PBR leggings next level wes anderson artisan four loko farm-to-table craft beer twee.'
            // }, {
            //     title: 'About',
            //     content: 'Etsy mixtape wayfarers, ethical wes anderson tofu before they sold out mcsweeney\'s organic lomo retro fanny pack lo-fi farm-to-table readymade.',
            //     disabled: true
            // }];
            // _this.scope.tabs.activeTab = 1;


            _this.scope.getLessonById();
        },
        _registerMethod: function() {
            var _this = this;
            _this.scope.getLessonById = function() {
                    _this.restSvc.get({
                        controller: 'Course',
                        action: 'CoursePlay',
                        id: _this.state.params.id
                    }, function(res) {
                        if (res.Result == 1) {
                            _this.scope.course = res.Data[0];
                        }
                    }, function(res) {

                    });
                },
                _this.scope.goBack = function() {
                    _this.rootScope.$emit('hideTabs', false);
                    _this.ionicHistory.goBack();
                    
                    //_this.rootScope.$emit('enableCategoryMenu', true);
                    //_this.state.go('tabs.lesson');
                }
        }
    }

})();
