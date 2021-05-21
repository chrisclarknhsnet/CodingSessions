using LINQExamples.POCOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LINQExamples
{
    public class Repository : IRepository
    {
        private IEnumerable<UserTakeup> _data;
        
        public Repository(IEnumerable<UserTakeup> data)
        {
            _data = data;
        }

        public DateTime? Get_WhenRegistered(string email)
        {
            try
            {
                return _data.SingleOrDefault(d => d.EmailAddress == email)?.FirstRegistered;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unexpected error, ensure email only occurs once in the data", ex);
            }
            
        }
    }
}
