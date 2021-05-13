using System;

namespace LINQExamples.POCOs
{
    public class UserTakeup
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Role { get; set; }
        public DateTime FirstRegistered { get; set; }
        public DateTime? LastAccessed { get; set; }
        public string OrganisationName { get; set; }
        public string ODSCode { get; set; }
        public string Sector { get; set; }
        public DateTime? DateProfileStarted { get; set; }
        public DateTime? DateProfileLastSubmitted { get; set; }
        public DateTime? DateAssessmentLastPublished { get; set; }
        public string AccountType { get; set; }
    }
}
