using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WidgetsStorageDemo.Models;

namespace WidgetsStorageDemo.Services
{
    public class WidgetsService
    {
        private readonly WidgetsContext _widgetsContext;

        public WidgetsService(WidgetsContext widgetsContext)
        {
            _widgetsContext = widgetsContext;
        }

        public async Task CreateWidget()
        {
            var widget = new WidgetVariation
            {
                Name = "Demo widget",
                States = new List<WidgetState>
                {
                    new WidgetState
                    {
                        WidgetContainers = new List<WidgetContainer>
                        {
                            new WidgetContainer
                            {
                                WidgetComponents = new List<WidgetComponent>
                                {
                                    new WidgetComponent()
                                }
                            }
                        }
                    }
                }
            };

            await _widgetsContext.WidgetVariations.AddAsync(widget);
            await _widgetsContext.SaveChangesAsync();

        }

        public async Task<WidgetVariation> GetWidget(int id)
        {
            return await _widgetsContext.WidgetVariations
                .Include(x => x.States)
                .ThenInclude(x => x.WidgetContainers)
                .ThenInclude(x => x.WidgetComponents)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
