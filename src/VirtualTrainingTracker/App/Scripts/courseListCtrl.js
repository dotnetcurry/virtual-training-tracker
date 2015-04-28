(function(module){
	module.controller('courseListCtrl', ['userInfoSvc', 'coursesDataSvc', function(userInfoSvc, coursesDataSvc) {
            var vm = this;

			function init(){
				coursesDataSvc.getAllCourses().then(function (result) {
					vm.courses = result;
				}, function (error) {
					console.log(error);
				});
			}

            vm.isAuthenticated = userInfoSvc.isAuthenticated();
			
            if(vm.isAuthenticated) {
                vm.addTrack = function (courseId) {
                    coursesDataSvc.addCourseToTrack({
                        courseId: courseId
                    }).then(function (result) {
                        init();
                    }, function (error) {
                        console.log(error);
                    });
                };
            }

			init();
        }]);
}(angular.module('virtualTrainingApp')));
	