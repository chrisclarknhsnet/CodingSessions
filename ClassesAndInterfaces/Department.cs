namespace ClassesAndInterfaces
{
    public class Department : IId
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int NoOfStudents { get; set; }
    }
}
