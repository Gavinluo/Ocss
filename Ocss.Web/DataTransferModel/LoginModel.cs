using System.ComponentModel.DataAnnotations;

namespace Ocss.Web.DataTransferModel
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public string Type { set; get; }
    }
}
