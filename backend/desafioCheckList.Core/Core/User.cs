namespace desafioCheckList.Core.Core
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Login { get; set; }
        public required string Password { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public class FilterUser
        {
            public string? Login { get; set; }
        }
    }
}
