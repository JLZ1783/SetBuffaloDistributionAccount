using Microsoft.Dexterity.Applications;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using Dapper;
using System.Data;
using System.Windows.Forms;
using ZeptoConnNet;

namespace SetBuffaloDistributionAccount
{
    class DataAccess
    {
       
        static public string ConnectionStringGP
        {

            get
            {
                string gpLoginType = "SQL";
                string gpServer = Controller.Instance.Model.GPServer;
                string gpDatabase = Controller.Instance.Model.GPCompanyDB;
                string gpUser = Controller.Instance.Model.GPUserID;
                string gpPassword = Controller.Instance.Model.GPPassword;

                if (gpLoginType == "SQL" && gpServer != string.Empty && gpDatabase != string.Empty && gpUser != string.Empty && gpPassword != string.Empty)
                {
                    //Return connection string for ".NET Framework Data Provider for SQL Server"  (System.Data.SqlClient.SqlConnection)
                    return @"Data Source=" + gpServer + ";Initial Catalog=" + gpDatabase + ";User ID=" + gpUser + ";Password=" + gpPassword + ";";
                }
                else if (gpLoginType.ToUpper() == "WINDOWS" && gpServer != string.Empty && gpDatabase != string.Empty)
                {
                    return @"Data Source=" + gpServer + ";Initial Catalog=" + gpDatabase + ";Integrated Security=SSPI;";
                }
                else
                {
                    return "";
                }

            }

        }
        internal static SqlConnection ConnectionGP()
        {
            SqlConnection sqlConn = new SqlConnection();
                                
                sqlConn = CreateGPConnection();
          
            return sqlConn;

        }

        private static SqlConnection CreateGPConnection()
        {
           
            SqlConnection sqlConn = ZeptoGPConn.GetConnection(Dynamics.Globals.SqlDataSourceName.Value, Controller.Instance.Model.GPCompanyDB, Dynamics.Globals.UserId.Value, Dynamics.Globals.SqlPassword.Value);

            return sqlConn;
        }

        internal static void SetBuffaloDistAccount()
        {
            SqlConnection sqlConn = ConnectionGP();
            var procedure = "[JLz_spSetBuffaloDistributionAccounts]";
            try
            {

                sqlConn.Query(procedure, commandType: CommandType.StoredProcedure);
                Dynamics.Forms.SyVisualStudioHelper.Functions.DexWarning.Invoke("Freight and miscellaneous distributions have been adjusted for all open invoices that were shipped out of Buffalo.");

            }
            catch (Exception ex)
            {

                MessageBox.Show("An unexpected error occurred in DataAccess.SetBuffaloDistAccount: " + ex.Message);
                
            }       
        }

    }
}
