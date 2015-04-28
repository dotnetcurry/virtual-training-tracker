using System;

namespace VirtualTrainingTracker.Models
{
    public class CourseTrackerDTO
    {
		public int CourseTrackerId { get; set; }
		public string CourseTitle { get; set; }
		public string Author { get; set; }
		public bool IsCompleted { get; set; }
	}
}