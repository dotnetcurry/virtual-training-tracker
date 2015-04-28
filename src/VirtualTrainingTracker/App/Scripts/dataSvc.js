(function(module){
	module.factory('coursesDataSvc', ['$http', function($http){
		function getAllCourses(){
			return $http.get('/api/courses').then(function(result){
				return result.data;
			}, function(error){
				return error;
			});
		}

		function getCourseTracks(){
			return $http.get('/api/courseTrackers').then(function(result){
				return result.data;
			}, function(error){
				return error;
			});
		}

		function addCourseToTrack(newCourse){
			return $http.post('/api/courseTrackers', {
				courseId: newCourse.courseId
			}).then(function(result){
				return result;
			}, function(error){
				return error;
			});
		};

		function modifyCourseTrack(courseTrackDetails){
			return $http.put('/api/courseTrackers/'+courseTrackDetails.courseTrackerId, {
				courseTrackerId: courseTrackDetails.courseTrackerId,
				isCompleted: true
			}).then(function(result){
				return result;
			}, function(error){
				return error;
			});
		};

		return {
			getAllCourses: getAllCourses,
			getCourseTracks: getCourseTracks,
			addCourseToTrack: addCourseToTrack,
			modifyCourseTrack: modifyCourseTrack
		};
	}]);
}(angular.module('virtualTrainingApp')));