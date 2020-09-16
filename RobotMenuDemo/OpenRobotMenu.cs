using SDK.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMenuDemo
{
    public class OpenRobotMenu : IAppSetting
    {
        public Form1 form1 = null;
        public void AppSetting()
        {
            if (form1 == null)
            {
                form1 = new Form1();
                form1.FormClosed += Form1_FormClosed; ;
                form1.ShowDialog();
            }
            else
            {
                form1.Activate();
            }
        }

        private void Form1_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            form1 = null;
        }
    }
}
