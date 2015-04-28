(function(){
	angular.module('virtualTrainingApp', ['ngRoute', 'virtualTrainingTemplates'])
		.config(['$routeProvider', function($routeProvider){
			//TODO: Configure routes
			$routeProvider.when('/courseList', {
				templateUrl: 'App/Templates/courseList.html',
				controller: 'courseListCtrl',
				controllerAs: 'vm'
			})
			.when('/courseTracks', {
				templateUrl: 'App/Templates/courseTracks.html',
				controller: 'courseTrackCtrl',
				controllerAs: 'vm'
			})
			.when('/courseTracks2', {
				templateUrl: 'App/Templates/courseTracks.html',
				controller: 'courseTrackCtrl',
				controllerAs: 'vm'
			})
			.otherwise({redirectTo: '/courseList'});
		}]);
}());