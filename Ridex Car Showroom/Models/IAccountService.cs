using Ridex_Car_Showroom.DAL;

namespace Ridex_Car_Showroom.Models
{
    public interface IAccountService
    {
        public Members Login(string username, string password);
    }
}
