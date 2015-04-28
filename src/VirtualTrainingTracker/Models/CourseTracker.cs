using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirtualTrainingTracker.Models
{
	public class CourseTracker
	{
		public int CourseTrackerID { get; set; }
		public int CourseID { get; set; }
		public string ApplicationUserId { get; set; }
		public bool IsCompleted { get; set; }
		public virtual Course Course { get; set; }
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}