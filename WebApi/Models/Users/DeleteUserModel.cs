using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class DeleteUserModel
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }
    }
}