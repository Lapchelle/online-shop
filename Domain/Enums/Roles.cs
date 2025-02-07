using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public class Roles
    {
        public static Guid Admin = Guid.Parse("5f01c4c3-bb8f-48d6-90f7-1769568ef562");
        public static Guid User = Guid.Parse("3ed1ea50-b91c-469a-898c-41bac15e427f");
        public static Guid Not_Auth = Guid.Parse("7893e308-10be-4873-ac12-29c482586e35");
    }
}
