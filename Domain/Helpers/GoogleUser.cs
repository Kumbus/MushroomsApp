namespace Domain.Helpers
{
    namespace Domain.Entities
    {
        public class GoogleUser
        {
            public string Email { get; set; }
            public string GivenName { get; set; } // First Name
            public string FamilyName { get; set; } // Last Name
            public string Picture { get; set; }
        }
    }

}
