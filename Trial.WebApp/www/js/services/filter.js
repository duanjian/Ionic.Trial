(function(){
	'use strict';

	angular
		.module('Trial.filter',[])
		.filter('emptyImg',function(){
			return function(args){
				return args = args == '' ? '/img/resource-cordova.png' : args;
			}
		})

})();