using Microsoft.AspNet.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using VirtualTrainingTracker.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualTrainingTracker.Controllers
{
	[Route("api/[controller]")]
	public class CoursesController : Controller
    {
		CourseRepository _repository;

		public CoursesController(CourseRepository repository)
		{
			this._repository = repository;
		}

		[HttpGet]
		public IEnumerable<CourseDTO> GetAllCourses()
		{
			return _repository.GetCourses((ClaimsIdentity)User.Identity);
		}
    }
}
