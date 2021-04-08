namespace ClassesAndInterfaces
{
    public interface IEmailer
    {
        void SendEmail();
        void SendEmail(string To);
        string To { get; set; }
    }
}
