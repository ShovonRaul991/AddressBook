using System.ComponentModel.DataAnnotations;

namespace AddressBook.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public string Email { get; set; }
        [Required]
        public long MobileNumber { get; set; }
        [Required]
        public long LandLineNumber { get; set; }
        public string Website { get; set; }
        public string AddressDetails { get; set; }
        /*
        public Address(string Name, string Email, long mobile, long landline, string website, string address) 
        {
            this.Name = Name;
            this.Email = Email;
            MobileNumber = mobile;
            LandLineNumber = landline;
            Website = website;
            AddressDetails = address;

        }
        */
    }
}
