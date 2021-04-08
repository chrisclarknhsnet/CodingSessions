using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public class YetAnotherEmail : EmailTemplateBase
    {
        protected override string getBody()
        {
            return "Some additional info\n\n";
        }

        protected override string getHeader()
        {
            return base.getHeader() + "\n\nYet Another Great Class\n\n";
        }

        protected override string getFooter()
        {
            return "\nThis is my custom footer";
        }
    }
}
