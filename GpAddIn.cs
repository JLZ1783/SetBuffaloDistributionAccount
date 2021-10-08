using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Dexterity.Bridge;
using Microsoft.Dexterity.Applications;

namespace SetBuffaloDistributionAccount
{
    public class GPAddIn : IDexterityAddIn
    {
        // IDexterityAddIn interface

        Microsoft.Dexterity.Applications.DynamicsDictionary.SopEntryForm sopEntryForm = Dynamics.Forms.SopEntry;
        

        public void Initialize()
        {
            sopEntryForm.AddMenuHandler(SetBuffaloDistributions, "Set Buffalo Shipping Dist.");
        }

        private void SetBuffaloDistributions(object sender, EventArgs e)
        {
            Controller.Instance.SetConnectionInfo();
            Controller.Instance.GetUserName();
            DataAccess.SetBuffaloDistAccount();
            if (sopEntryForm.IsOpen)
            {
                sopEntryForm.SopEntry.DisplayExistingRecord.RunValidate();
            }
        }
    }
}
