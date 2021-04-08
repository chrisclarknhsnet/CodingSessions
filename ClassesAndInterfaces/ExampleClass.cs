namespace ClassesAndInterfaces
{
    public class ExampleClass
    {
        protected int _myProperty = -1;

        public int MyVariable;

        public int MyProperty 
        { 
            get
            {
                return _myProperty;
            }
        }

        public override string ToString()
        {
            return $"ExampleClass with MyProperty set to {this.MyProperty}";
        }
    }
}
