using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;

namespace VirtualTrainingTracker.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseTracker> CourseTrackers { get; set; }

		public ApplicationDbContext()
        {            
            // Create the database and schema if it doesn't exist
            // This is a temporary workaround to create database until Entity Framework database migrations 
            // are supported in ASP.NET 5
        }
        
        protected override void OnConfiguring(DbContextOptions options)
        {
            options.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
			// Customize the ASP.NET Identity model and override the defaults if needed.
			// For example, you can rename the ASP.NET Identity table names and more.
			// Add your customizations after calling base.OnModelCreating(builder);

			//builder.Entity<CourseTracker>().Key(ct => ct.TrackerID);

			builder.Entity<CourseTracker>(b => b.HasOne<Course>(ct => ct.Course));
			builder.Entity<Course>(b => b.HasMany<CourseTracker>(c => c.Trackers));

			//builder.Entity<CourseTracker>().HasOne<Course>(ct => ct.Course).WithMany(c => c.Trackers);
			builder.Entity<CourseTracker>().HasOne<ApplicationUser>(ct => ct.ApplicationUser).WithMany();

			//builder.Entity<CourseTracker>(b => b.HasOne<ApplicationUser>(c => c.User));			
			//builder.Entity<CourseTracker>().HasOne<ApplicationUser>(ct => ct.User).WithOne().ForeignKey(typeof(CourseTracker), "UserID");

			//builder.Entity<CourseTracker>(b => b.);
			//builder.Entity<ApplicationUser>(b => b.HasMany<CourseTracker>());			
		}
	}
}