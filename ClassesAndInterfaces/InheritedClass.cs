namespace ClassesAndInterfaces
{
    public class InheritedClass : ExampleClass
    {
        public string MyOtherProperty
        {
            get;
            set;
        }

        public void AddOneToMyProperty()
        {
            base._myProperty++;
        }
    }
}
