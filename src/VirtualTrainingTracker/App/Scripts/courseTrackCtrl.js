(function(module){
	module.controller('courseTrackCtrl', ['userInfoSvc', 'coursesDataSvc', function(userInfoSvc, coursesDataSvc) {
			var vm = this;

			function init(){
				coursesDataSvc.getCourseTracks().then(function(result){
					vm.courses = result.data? result.data : result;
				});
			}

			vm.completeCourse = function(courseTrackerId){
				coursesDataSvc.modifyCourseTrack({courseTrackerId: courseTrackerId})
					.then(function(result){
						init();
					}, function(error){
						console.log(error);
					});
			};

			init();
		}]);
}(angular.module('virtualTrainingApp')));