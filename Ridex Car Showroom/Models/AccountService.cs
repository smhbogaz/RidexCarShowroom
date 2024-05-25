using Ridex_Car_Showroom.DAL;

namespace Ridex_Car_Showroom.Models
{
    public class AccountService : IAccountService
    {
        public Members Login(string username, string password)
        {
            using (AppDbContext db = new AppDbContext())
            {
                return db.Members.SingleOrDefault(x => x.Username == username && x.Password == password);
            }
        }
    }
}
