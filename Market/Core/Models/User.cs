using System.ComponentModel;

namespace Market.Core.Models
{
    public enum Roles
    {
        [Description("Администратор")]
        Admin,
        [Description("Рабочий")]
        Worker
    }

    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public String FIO { get; set; }
        public Roles Role { get; set; }
    }
}
