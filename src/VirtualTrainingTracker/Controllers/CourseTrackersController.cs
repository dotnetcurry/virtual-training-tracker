using Microsoft.AspNet.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using VirtualTrainingTracker.Models;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualTrainingTracker.Controllers
{
	[Route("api/[controller]")]
	public class CourseTrackersController : Controller
	{
		CourseTrackerRepository _repository;

		public CourseTrackersController(CourseTrackerRepository repository)
		{
			this._repository = repository;
		}

		[HttpGet]
		[Authorize]
		public IEnumerable<CourseTrackerDTO> GetCoursesOfUser()
		{
			var userId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;
			var trackers = _repository.GetCourseTrackers(userId);
			return trackers;
		}

		[HttpPost]
		[Authorize]
		public CourseTracker AddCourseTracker([FromBody]CourseTracker tracker)
		{
			try
			{
				tracker.ApplicationUserId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;
				return _repository.AddTracker(tracker);
            }
			catch (System.Exception ex)
			{
				throw new System.Exception("Couldn't add the course to tracking");
			}
		}

		[HttpPut("{trackerId:int}")]
		[Authorize]
		public CourseTracker UpdateCourseAsWatched(int trackerId, [FromBody]CourseTracker updatedTracker)
		{
			try
			{
				return _repository.UpdateCourseTracker(updatedTracker);
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("Couldn't update the course track");
			}
		}
	}
}
