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
            public const int NameMinLength = 1;
            public const int NameMaxLength = 2;
            public const int DescriptionMinLength = 1;
            public const int DescriptionMaxLength = 2;
        }
    }
}
