namespace DevConnector.Services
{
    public class AdminService : UserService
    {
        public AdminService(ApplicationDbContext context) : base(context) { }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
