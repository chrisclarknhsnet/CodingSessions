using System.Collections.Generic;

namespace LINQExamples.POCOs
{
    public class Book
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public AuthorInfo Author { get; set;}
        public IList<string> Categories { get; set; }
    }
}
