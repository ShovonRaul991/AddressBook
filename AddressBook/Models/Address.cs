namespace AddressBook.Models
{
    public class Address
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public int LandLineNumber { get; set; }
        public string Website { get; set; }
        public string AddressDetails { get; set; }

        public Address(string Name,string Email,int MobileNumber, int LandLineNumber, string Website, string AddressDetails) 
        {
            this.Name = Name;
            this.Email = Email;
            this.MobileNumber = MobileNumber;
            this.LandLineNumber = LandLineNumber;
            this.Website = Website;
            this.AddressDetails = AddressDetails;
        }
    }
}
