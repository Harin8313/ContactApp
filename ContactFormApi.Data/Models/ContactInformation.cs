using System.ComponentModel.DataAnnotations;

namespace ContactFormApi.Data.Models
{
    public class ContactInformation
    {
        public ContactInformation()
        {
            
        }
        //Key
        public int  Id { get; set; }     
        
        [Required]  
        [StringLength(60)]    
        public string  FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string  LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(10)]
        public string  PhoneNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

    }
}
