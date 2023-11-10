using API_QLHocVien.Context;

namespace API_QLHocVien.Services
{
    public class BaseServices
    {
        public readonly AppDbContext dbContext;

        public BaseServices()
        {
            dbContext = new AppDbContext();
        }
    }
}
