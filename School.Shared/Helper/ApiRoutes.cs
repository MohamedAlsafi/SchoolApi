using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Shared.Helper
{
    public static class ApiRoutes
    {
        public const string Root = "Api/";
        public const string SingleRoute = "{Id}";
        public const string Paginate = "Paginated";



        public static class StudentRouting
        {
            public const string prifix = Root + "Student/";
            public const string List = prifix + "List";
            public const string GetById = prifix + SingleRoute;
            public const string Create = prifix + "Create";
            public const string Update = prifix + "Update";
            public const string Delete = prifix + "Delete";
            public const string Paginated = prifix + Paginate;
        }


        public static class DepartmentRouting
        {
            public const string prifix = Root + "Department/";
            public const string List = prifix + "List";
            public const string GetById = prifix + SingleRoute;
            public const string Create = prifix + "Create";
            public const string Update = prifix + "Update";
            public const string Delete = prifix + "Delete";
            public const string Paginated = prifix + Paginate;
        }

        public static class UserRouting
        {
            public const string Prefix = Root + "User";
            public const string Create = Prefix + "/Create";
            public const string Paginated = Prefix + "/Paginated";
            public const string GetByID = Prefix + SingleRoute;
            public const string Edit = Prefix + "/Edit/{id}";
            public const string Delete = Prefix + "/{id}";
            public const string ChangePassword = Prefix + "/Change-Password";
        }
        public static class Authentication
        {
            public const string Prefix = Root + "Authentication/";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
            public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";
            public const string ResetPassword = Prefix + "/ResetPassword";

        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Root + "AuthorizationRouting";
            public const string Roles = Prefix + "/Roles";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{id}";
            public const string RoleList = Roles + "/Role-List";
            public const string GetRoleById = Roles + "/Role-By-Id/{id}";
            public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string UpdateUserClaims = Claims + "/Update-User-Claims";
        }
        public static class EmailsRoute
        {
            public const string Prefix = Root + "EmailsRoute";
            public const string SendEmail = Prefix + "/SendEmail";
        }
        public static class InstructorRouting
        {
            public const string Prefix = Root + "InstructorRouting";
            public const string GetSalarySummationOfInstructor = Prefix + "/Salary-Summation-Of-Instructor";
            public const string AddInstructor = Prefix + "/Create";
        }
    }

   
}
