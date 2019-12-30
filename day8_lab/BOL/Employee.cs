
using System.ComponentModel.DataAnnotations;
namespace BOL
{
   public  class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
    }
}
