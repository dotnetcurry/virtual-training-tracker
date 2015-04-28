using System;
using System.Collections.Generic;

namespace VirtualTrainingTracker.Models
{
	public class Course
	{
		public int CourseID { get; set; }
		public string Title { get; set; }
		public int Duration { get; set; }
		public string Author { get; set; }
		public virtual ICollection<CourseTracker> Trackers { get; set; }
	}
}