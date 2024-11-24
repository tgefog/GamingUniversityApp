namespace GamingUniversityApp.Common
{
    public static class EntityValidationMessages
    {
        public static class Course
        {
            public const string NameRequiredMessage = "Course name is required.";
            public const string DescriptionRequiredMessage = "Course description required.";
            public const string CreditsRequiredMessage = "Course credits required.";
        }
        public static class Assignment
        {
            public const string NameRequiredMessage = "Assignment name is required.";
            public const string DescriptionRequiredMessage = "Assignment description required.";
            public const string DueDateRequiredMessage = "Assignment due date is required.";

        }
    }
}