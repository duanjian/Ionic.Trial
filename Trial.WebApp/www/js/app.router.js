(function() {
    'use strict';

    angular
        .module('Trial')
        .config(function($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state('tabs', {
                    url: '/tab',
                    abstract: true,
                    templateUrl: 'templates/tabs.tpl.html',
                    controller: 'TabsCtrl'
                })
                .state('login', {
                    url: '/login',
                    // views: {
                    //     'login-view': {
                    //         templateUrl: 'templates/login.tpl.html',
                    //         controller: 'LoginCtrl'
                    //     }
                    //}
                    templateUrl: 'templates/login.tpl.html',
                    controller: 'LoginCtrl'
                   
                })
                .state('tabs.info', {
                    url: '/info',
                    views: {
                        'tab-info': {
                            templateUrl: 'templates/info.tpl.html',
                            controller: 'InfoCtrl'
                        }
                    },
                    onEnter: function($rootScope) {
                        $rootScope.$emit('enableCategoryMenu', false);
                    }
                })
                .state('tabs.info-details', {
                    url: '/info/:id/:date',
                    views: {
                        'tab-info': {
                            templateUrl: 'templates/info.details.tpl.html',
                            controller: 'InfoDetailsCtrl'
                        }
                    },
                    onEnter: function($rootScope) {
                        $rootScope.$emit('hideTabs', true);
                    }
                })
                .state('tabs.info-comment', {
                    url: '/info/:id/:date/comment',
                    views: {
                        // 'info-comment':{
                        //     templateUrl:'templates/info.comment.tpl.html',
                        //     controller:'InfoCommentCtrl'
                        // }
                        'tab-info': {
                            templateUrl: 'templates/info.comment.tpl.html',
                            controller: 'InfoCommentCtrl'
                        }
                    }
                })
                .state('tabs.lesson', {
                    url: '/lesson/:cid',
                    views: {
                        'tab-lesson': {
                            templateUrl: 'templates/lesson.tpl.html',
                            controller: 'LessonCtrl'
                        }
                    },
                    onEnter: function($rootScope) {
                        $rootScope.$emit('enableCategoryMenu', true);
                    }
                })
                .state('tabs.lesson-details', {
                    url: '/lesson/:cid/:id',
                    views: {
                        'tab-lesson': {
                            templateUrl: 'templates/lesson.details.tpl.html',
                            controller: 'LessonDetailsCtrl'
                        }
                    },
                    onEnter: function($rootScope) {
                        $rootScope.$emit('hideTabs', true);
                    }
                });
            //Default Router
            $urlRouterProvider.otherwise('/tab/info');

        });       
    // .run(['$rootScope', '$state', '$stateParams', function($rootScope, $state, $stateParams) {
    //     $rootScope.$state = $state;
    //     $rootScope.$stateParams = $stateParams;
    // }]);

})();
