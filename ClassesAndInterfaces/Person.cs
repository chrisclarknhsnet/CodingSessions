namespace ClassesAndInterfaces
{
    public class Person : IId, IName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
