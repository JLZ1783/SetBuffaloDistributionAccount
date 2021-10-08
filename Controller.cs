using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Data;

namespace SetBuffaloDistributionAccount
{
    public class Controller
    {
        private static  Model model = new Model();
        private static readonly Controller instance = new Controller();

        public Model Model
        {
            get
            {
                return Controller.model;
            }
        }

        public static Controller Instance
        {
            get
            {
                return Controller.instance;
            }
        }

        public void SetConnectionInfo()
        {
            Microsoft.Dexterity.Applications.DynamicsDictionary.SyBackupRestoreForm backup;
            backup = Microsoft.Dexterity.Applications.Dynamics.Forms.SyBackupRestore;
            model.GPServer = backup.Functions.GetServerNameWithInstance.Invoke();
            model.GPUserID = Microsoft.Dexterity.Applications.Dynamics.Globals.UserId.Value;
            model.GPPassword = Microsoft.Dexterity.Applications.Dynamics.Globals.SqlPassword.Value;
            model.GPSystemDB = Microsoft.Dexterity.Applications.Dynamics.Globals.SystemDatabaseName.Value;
            model.GPCompanyDB = Microsoft.Dexterity.Applications.Dynamics.Globals.IntercompanyId.Value;
            
        }
        public void GetUserName()
        {
            model.GPUserName = Microsoft.Dexterity.Applications.Dynamics.Globals.UserName;
        }

    }



}
