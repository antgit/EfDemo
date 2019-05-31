using System.Threading.Tasks;

namespace WidgetsStorageDemo.Services
{
    public class UnitOfWork
    {
        private readonly WidgetsContext _widgetsContext;

        public UnitOfWork(WidgetsContext widgetsContext)
        {
            _widgetsContext = widgetsContext;
        }

        public Task Save()
        {
            return _widgetsContext.SaveChangesAsync();
        }
    }
}
