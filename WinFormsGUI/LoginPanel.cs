using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBooking.WFORM
{
    internal class LoginPanel
    {
        static LoginPanel instance = null;
        static MainForm mainForm = null;

        public static LoginPanel GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginPanel();
            }
            if (mainForm == null)
            {
                throw new Exception("Main form reference not set");
            }
            return instance;
        }

        public static LoginPanel GetInstance(MainForm form)
        {
            mainForm = form;
            return GetInstance();
        }
    }
}
