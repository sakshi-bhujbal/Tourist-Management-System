namespace example.models
{
    public class Register
    {
        public required string Name { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }

        public required string phoneNumber { get; set; }
        public required string birthdate { get; set; }
        public required string gender { get; set; }
        public required string city { get; set; }
    }
}
