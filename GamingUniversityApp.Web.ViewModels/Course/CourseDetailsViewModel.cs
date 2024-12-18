﻿namespace GamingUniversityApp.Web.ViewModels.Course
{
    using Data.Models;
    using GamingUniversityApp.Web.ViewModels.Assignment;

    public class CourseDetailsViewModel
    {
        public string Id { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CourseName { get; set; } = null!;
        public int Credits { get; set; }
        public string ImageUrl { get; set; } = null!;
        public IEnumerable<AssignmentInCourseViewModel> Assignments { get; set; } = new HashSet<AssignmentInCourseViewModel>();

    }
}