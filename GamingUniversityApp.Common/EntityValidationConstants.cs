using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingUniversityApp.Common
{
    public static class EntityValidationConstants
    {
        public static class Course
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;
        }
        public static class Assignment
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 200;
            public const string DueDateFormat = "dd/MM/yyyy";
        }
        public static class Student
        {
            public const int FirstNameMinLength = 3;
            public const int FirstNameMaxLength = 50;
            public const int LastNameMinLength = 3;
            public const int LastNameMaxLength = 50;
            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 100;
        }
		public static class Submission
		{
			public const string SubmissionDateFormat = "dd/MM/yyyy";
		}
		public static class StudentCourse
        {
			public const string EnrollmentDateFormat = "dd/MM/yyyy";
		}
    }
}
