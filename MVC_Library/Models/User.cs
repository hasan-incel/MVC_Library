namespace MVC_Library.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime JoinDate { get; set; }

        public User()
        {
            JoinDate = DateTime.Now; // Varsayılan kayıt tarihi
        }
    }
}
