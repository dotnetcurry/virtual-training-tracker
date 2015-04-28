using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualTrainingTracker.Models
{
	public class CourseTrackerRepository
	{
		ApplicationDbContext _context;

		public CourseTrackerRepository(ApplicationDbContext context)
		{
			this._context = context;
		}

		public IEnumerable<CourseTrackerDTO> GetCourseTrackers(string userId)
		{
			var userTrackers = _context.CourseTrackers.Where(ct => ct.ApplicationUserId == userId);
			var trackerDtoList = new List<CourseTrackerDTO>();

			foreach (var tracker in userTrackers)
			{
				var course = _context.Courses.FirstOrDefault(c => c.CourseID == tracker.CourseID);

				trackerDtoList.Add(new CourseTrackerDTO()
				{
					CourseTrackerId = tracker.CourseTrackerID,
					CourseTitle = course.Title,
					Author = course.Author,
					IsCompleted = tracker.IsCompleted
				});
			}

			return trackerDtoList;
		}

		public CourseTracker UpdateCourseTracker(CourseTracker updatedTracker)
		{
			var tracker = _context.CourseTrackers.FirstOrDefault(ct => ct.CourseTrackerID == updatedTracker.CourseTrackerID);

			if (tracker != null)
			{
				tracker.IsCompleted = updatedTracker.IsCompleted;

				_context.Entry(tracker).SetState(Microsoft.Data.Entity.EntityState.Modified);

				_context.SaveChanges();
				return tracker;
			}

			return null;
		}

		public CourseTracker AddTracker(CourseTracker tracker)
		{
			tracker.IsCompleted = false;

			if (_context.CourseTrackers.FirstOrDefault(ct => ct.CourseID == tracker.CourseID && tracker.ApplicationUserId == tracker.ApplicationUserId) == null)
			{
				var addedTracker = _context.Add(tracker);
				_context.SaveChanges();
				return tracker;
			}

			return null;
		}
	}
}