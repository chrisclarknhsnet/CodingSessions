using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public abstract class EmailTemplateBase : IEmailer
    {
        public void SendEmail(string to)
        {
            this.To = to;
            SendEmail();
        }

        public void SendEmail()
        {
            if (string.IsNullOrWhiteSpace(this.To))
            {
                throw new NullReferenceException("You must set who the email is being sent To");
            }

            var msg = getHeader() + getBody() + getFooter();
            Console.WriteLine(msg);
            Console.WriteLine();
        }

        public string To { get; set; }

        protected virtual string getHeader()
        {
            return "This is our header\n\n";
        }

        protected abstract string getBody();

        protected virtual string getFooter()
        {
            return "\n\nThis is our footer";
        }
    }
}
