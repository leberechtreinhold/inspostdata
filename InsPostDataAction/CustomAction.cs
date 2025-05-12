using Microsoft.Deployment.WindowsInstaller;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace InsPostDataAction
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult GetInsPostDataFn(Session session)
        {
            session.Log("Begin GetInsPostDataFn");

            string msg = "";

            try
            {
                msg += "Original Database: " + session["OriginalDatabase"] + "\n";
                Console.WriteLine(session["OriginalDatabase"]);

                var bytes = File.ReadAllBytes(session["OriginalDatabase"]);
                msg += "Read " + bytes.Length + " bytes" + "\n";

                int last_block_start = ((bytes.Length / 64) - 1) * 64;
                int last_block_len = bytes.Length - last_block_start;
                byte[] last_block = new byte[last_block_len];
                Array.Copy(bytes, last_block_start, last_block, 0, last_block_len);
                var str = Encoding.Default.GetString(last_block).Trim('\0');
                msg += "PostData: " + str + "\n";
            }
            catch (Exception ex)
            {
                msg += "Failed to get Original db " + ex + "\n";
            }

            MessageBox.Show(msg);

            return ActionResult.Success;
        }
    }
}
