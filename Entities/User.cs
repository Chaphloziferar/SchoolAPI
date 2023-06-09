namespace Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}