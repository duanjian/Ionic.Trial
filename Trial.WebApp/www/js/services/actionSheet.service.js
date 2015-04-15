(function() {
    'use strict';

    angular
        .module('Trial.actionSheet', ['ionic'])
        .directive('shareSheet', ['$ionicActionSheet', function($ionicActionSheet) {
            return {
                restrict: 'A',
                link: function(scope, element, attr) {
                    element.on('click', function(event) {
                        var shareSheet = $ionicActionSheet.show({
                            buttons: [{
                                text: '腾讯微博'
                            }, {
                                text: '微信好友'
                            }],
                            titleText: '分享',
                            cancelText: '取消'
                                // cancel: function(){
                                //     shareSheet.hide();
                                // }
                        });
                    })
                }
            }
        }]);

})();
