(function(module){
	module.service('userInfoSvc', ['$window', function($window){
		var isUserAuthenticated = false, userName;

		if($window.userName){
			isUserAuthenticated = true;
			userName = $window.userName;
		}

		this.getUserName = function(){
			return userName;
		};

		this.isAuthenticated = function(){
			return isUserAuthenticated;
		};
	}]);
}(angular.module('virtualTrainingApp')));