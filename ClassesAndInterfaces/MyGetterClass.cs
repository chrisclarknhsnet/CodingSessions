using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassesAndInterfaces
{
    public class MyGetterClass
    {
        public T FindById<T>(IList<T> col, int Id) where T : IId
        {
            return col.SingleOrDefault(e => e.Id == Id);
        }

        public T FindByName<T>(IList<T> col, string name) where T : IName
        {
            return col.SingleOrDefault(e => e.Name.ToLower() == name.ToLower());
        }
    }
}
