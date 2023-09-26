using Pusdafi_Dev.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Pusdafi_Dev.ViewModels.LoginVM
{
    public class LoginVM
    {
        ///public string Id { get; set; }
        //public string Name { get; set; }
        //public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool rememberMe { get; set; }
    }
}
