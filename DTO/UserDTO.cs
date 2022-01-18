using System.ComponentModel.DataAnnotations;

namespace ProiectDAW.Controllers
{
    public class UserDTO
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        //[StringLength(24)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressId { get; set; }
    }
}