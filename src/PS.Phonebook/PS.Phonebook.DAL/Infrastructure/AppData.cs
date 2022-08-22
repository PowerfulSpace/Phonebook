using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Phonebook.DAL.Infrastructure
{
    public static class AppData
    {
        public const string UserRoleName = "User";
        public const string ManagerRoleName = "Manager";
        public const string AdministratorRoleName = "Administrator";

        public static IEnumerable<string> Roles
        {
            get
            {
                yield return UserRoleName;
                yield return ManagerRoleName;
                yield return AdministratorRoleName;
            }
        }
    }
}
