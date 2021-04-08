using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassesAndInterfaces
{
    public class PointCollection : IEnumerable
    {
        private ArrayList _col;

        public PointCollection()
        {
            _col = new ArrayList();
        }

        public void Add(Point value)
        {
            _col.Add(value);
        }

        public IEnumerator GetEnumerator()
        {
            return _col.GetEnumerator();
        }

        public Point this[int index]
        {
            get
            {
                return (Point)_col[index];
            } 
            set
            {
                _col[index] = value;
            } 
        }
    }
}
