using System.Threading.Tasks;

namespace WidgetsStorageDemo.Services
{
    public class UnitOfWorkService
    {
        private readonly WidgetsContext _widgetsContext;

        public UnitOfWorkService(WidgetsContext widgetsContext)
        {
            _widgetsContext = widgetsContext;
        }

        public Task SaveChanges()
        {
            return _widgetsContext.SaveChangesAsync();
        }
    }
}
