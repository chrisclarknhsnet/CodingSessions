namespace ClassesAndInterfaces
{
    public class NewFeatureEmail : EmailTemplateBase
    {
        protected override string getBody()
        {
            return "Hey check out our new groovy features";
        }
    }
}
