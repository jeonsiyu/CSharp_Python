using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class DataManager
    {
        public static Manager loginedAdmin;
        public static bool login(string managerCode, string managerId, string managerPw)
        {
            string manager_name = null;
            if (DBHelper.selectQuery(managerCode, managerId, managerPw, ref manager_name))
            {
                loginedAdmin = new Manager();
                loginedAdmin.manager_code = managerCode;
                loginedAdmin.manager_id = managerId;
                loginedAdmin.manager_pw = managerPw;
                loginedAdmin.manager_name = manager_name;
                return true;
            }
            return false;
        }
    }
}
