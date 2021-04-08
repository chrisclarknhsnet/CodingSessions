using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public class NewUserEmail
    {
        protected virtual string getHeader()
        {
            return "The really funky system\n\n";
        }

        protected virtual string getFooter()
        {
            return "\n\nPlease note we take no responsibility for anything, ever\n\n";
        }

        public void SendEmail(string newusername)
        {
            var body = $"We have set up the user {newusername} on our system.  Have fun";
            var msg = getHeader() + body + getFooter();
            doTheSend(msg);
            Console.Write("Message sent");
        }

        private bool doTheSend(string msg)
        {
            Console.WriteLine(msg);
            return true;
        }
    }
}
