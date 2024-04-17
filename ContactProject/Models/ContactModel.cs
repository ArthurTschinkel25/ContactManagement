using System.ComponentModel.DataAnnotations;

namespace ContactProject.Models
{  
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "A name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "An email is required!")]
        [EmailAddress(ErrorMessage = "Please enter a correct email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A phone number is required!")]
        [Phone(ErrorMessage = "Please enter a correct phone number")]
        public string Phone { get; set; }
    }
}
