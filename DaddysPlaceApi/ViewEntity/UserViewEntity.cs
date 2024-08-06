namespace DaddysPlaceApi.ViewEntity
{
    public class UserViewEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public string Role { get; set; }
    }

    public class UserVEditEntity
    {
        public int Id { get; set; }
      
        public bool Status { get; set; }
      
    }
    public class UserEditVRoleEntity
    {
        public int Id { get; set; }

        public string Role { get; set; }

    }
}
