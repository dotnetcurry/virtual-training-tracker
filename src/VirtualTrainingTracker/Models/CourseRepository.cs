using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace VirtualTrainingTracker.Models
{
    public class CourseRepository
    {
		ApplicationDbContext _context;

		public CourseRepository(ApplicationDbContext context)
		{
			this._context = context;
		}

		public IEnumerable<CourseDTO> GetCourses(ClaimsIdentity identity)
		{
			if (identity.IsAuthenticated)
			{
				var userId = identity.Claims.FirstOrDefault().Value;

				var userTrackers = _context.CourseTrackers.Where(ct => ct.ApplicationUserId == userId);

				var withTrackStatus = this._context.Courses.Select(c => new CourseDTO()
				{
					Tracked = userTrackers.FirstOrDefault(t => t.CourseID == c.CourseID),
					CourseId = c.CourseID,
					Author = c.Author,
					Title = c.Title,
					Duration = c.Duration
				});

				return withTrackStatus.ToList();
			}

			return this._context.Courses.Select(c => new CourseDTO()
			{
				Tracked = null,
				CourseId = c.CourseID,
				Author = c.Author,
				Title = c.Title,
				Duration = c.Duration
			}).ToList();
		}
    }
}