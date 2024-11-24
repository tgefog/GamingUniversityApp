using System.Reflection.Metadata;

namespace GamingUniversityApp.Common
{
    public static class ErrorMessages
    {
        public static class MyCourses
        {
            public const string AddToMyCoursesNotSuccessfullMessage = 
                "Unexpected error occured while adding the course to your courses!";
        }
        public static class Course 
        {
            public const string EditCourseNotSuccessfullMessage =
                "Unexpected error occured while updating the course! Please contact administrator!";
            public const string DeleteCourseNotSuccessfullMessage =
                "Unexpected error occured while trying to delete the course! Please contact system administrator!";
		}
    }
}