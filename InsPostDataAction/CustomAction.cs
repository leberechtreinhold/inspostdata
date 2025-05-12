using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InsPostDataAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult GetInsPostDataFn(Session session)
        {
            session.Log("Begin GetInsPostDataFn");
            MessageBox.Show("Hey from GetInsPostDataFn");
            return ActionResult.Success;
        }
    }
}
