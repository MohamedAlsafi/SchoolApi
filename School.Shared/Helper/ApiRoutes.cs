using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Shared.Helper
{
    public static class ApiRoutes
    {
        public const string Root = "Api/";
        public const string SingleRoute = "{Id}";


        public static class StudentRouting
        {
            public const string prifix = Root + "Student/";
            public const string List = prifix + "List";
            public const string GetById = prifix + SingleRoute;
            public const string Create = prifix + "Create";




        }
    }

   
}
