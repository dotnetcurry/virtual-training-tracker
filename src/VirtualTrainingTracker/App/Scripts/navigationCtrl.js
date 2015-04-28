(function(module){
	module.controller('navigationCtrl', ['userInfoSvc', function(userInfoSvc){
			var nav = this;
			nav.navigationList = [{url:'#/courseList', text: 'Course List'}, {url:'#/courseTracks', text: 'Course Track'}];
			nav.isAuthenticated = userInfoSvc.isAuthenticated();
		}]);
}(angular.module('virtualTrainingApp')));