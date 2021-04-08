namespace ClassesAndInterfaces
{
    public class NewOrganisationEmail : EmailTemplateBase
    {
        private string _orgcode;
        private string _orgname;

        public NewOrganisationEmail(string orgcode, string orgname)
        {
            this._orgcode = orgcode;
            this._orgname = orgname;
        }

        protected override string getBody()
        {
            return $"New organisation available\n\nCode: {this._orgcode}\nName: {this._orgname}";
        }
    }
}
