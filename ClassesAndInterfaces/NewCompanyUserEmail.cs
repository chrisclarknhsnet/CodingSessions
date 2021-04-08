using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public class NewCompanyUserEmail : NewUserEmail
    {
        protected override string getHeader()
        {
            return "We are a new exciting company, not like the last one\n\n";
        }

        protected override string getFooter()
        {
            return "\n\nThis is a new footer note\n\n" + base.getFooter();
        }
    }
}
