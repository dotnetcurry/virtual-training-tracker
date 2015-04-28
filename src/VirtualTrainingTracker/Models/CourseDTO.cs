using System;
using System.Collections.Generic;

namespace VirtualTrainingTracker.Models
{
	public class CourseDTO
	{
		public string Author { get; internal set; }
		public int CourseId { get; internal set; }
		public int Duration { get; internal set; }
		public string Title { get; internal set; }
		public CourseTracker Tracked { get; internal set; }
	}
}