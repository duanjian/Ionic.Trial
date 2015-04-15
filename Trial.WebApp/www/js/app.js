// Ionic Starter App

// angular.module is a global place for creating, registering and retrieving Angular modules
// 'starter' is the name of this angular module example (also set in a <body> attribute in index.html)
// the 2nd parameter is an array of 'requires'
angular.module('Trial', ['ionic','mgcrea.ngStrap', 'Trial.restfull', 'Trial.actionSheet','Trial.filter'])

.run(function($ionicPlatform, $rootScope, $state, $stateParams,$ionicLoadingConfig) {
        $ionicPlatform.ready(function() {
            // Hide the accessory bar by default (remove this to show the accessory bar above the keyboard
            // for form inputs)
            if (window.cordova && window.cordova.plugins.Keyboard) {
                cordova.plugins.Keyboard.hideKeyboardAccessoryBar(true);
            }
            if (window.StatusBar) {
                StatusBar.styleDefault();
            }

            //$rootScope.hideTabs = false;

        });
    })
    .config(function($ionicConfigProvider) {
        $ionicConfigProvider.tabs.position('bottom');
        $ionicConfigProvider.navBar.alignTitle('center')
    })
    .constant('$ionicLoadingConfig', {
        content: '<ion-spinner icon="ios"></ion-spinner>',
        animation: 'fade-in',
        showBackdrop: true,
        maxWidth: 200,
        showDelay: 0
    });
