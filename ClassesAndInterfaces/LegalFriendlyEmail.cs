using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public class LegalFriendlyEmail : NewUserEmail
    {
        protected override string getFooter()
        {
            var stdFooter = base.getFooter();
            return $"{stdFooter}\n\nWe accept nothing, EVER!!!!";
        }
    }
}
