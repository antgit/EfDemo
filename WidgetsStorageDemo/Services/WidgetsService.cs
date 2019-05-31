using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<int> CreateWidget()
        {
            var widget = new WidgetVariation
            {
                Name = "Demo widget",
                States = new List<WidgetState>
                {
                    new WidgetState
                    {
                        Name = "Widget state 1",
                        WidgetContainers = new List<WidgetContainer>
                        {
                            new WidgetContainer
                            {
                                Name = "Widget container 1.1",
                                WidgetComponents = new List<WidgetComponent>
                                {
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 1.1.1",
                                    },
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 1.1.2",
                                    }
                                }
                            },
                            new WidgetContainer
                            {
                                Name = "Widget container 1.2",
                                WidgetComponents = new List<WidgetComponent>
                                {
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 1.2.1",
                                    },
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 1.2.2",
                                    }
                                }
                            }
                        }
                    },
                    new WidgetState
                    {
                        Name = "Widget state 2",
                        WidgetContainers = new List<WidgetContainer>
                        {
                            new WidgetContainer
                            {
                                Name = "Widget container 2.1",
                                WidgetComponents = new List<WidgetComponent>
                                {
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 2.1.1",
                                    },
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 2.1.2",
                                    }
                                }
                            },
                            new WidgetContainer
                            {
                                Name = "Widget container 1.2",
                                WidgetComponents = new List<WidgetComponent>
                                {
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 2.2.1",
                                    },
                                    new WidgetComponent
                                    {
                                        Name = "Widget component 2.2.2",
                                    }
                                }
                            }
                        }
                    },
                },
                Audiences = new List<WidgetAudience>
                {
                    new WidgetAudience
                    {
                        Name = "Widget audience 1"
                    },
                    new WidgetAudience
                    {
                        Name = "Widget audience 2"
                    }
                }
            };

            await _widgetsContext.WidgetVariations.AddAsync(widget);
            await _widgetsContext.SaveChangesAsync();

            return widget.Id;
        }

        public async Task<WidgetVariation> GetWidget(int id)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            var result =  await _widgetsContext.WidgetVariations
                .Include(x => x.Audiences)
                .Include(x => x.States)
                    .ThenInclude(x => x.WidgetContainers)
                        .ThenInclude(x => x.WidgetComponents)
                .FirstOrDefaultAsync(x => x.Id == id);

            stopWatch.Stop();

            return result;
        }

        public async Task Delete(int id)
        {
            var widget = await _widgetsContext.WidgetVariations.FindAsync(id);

            if(widget == null)
            {
                return;
            }

            _widgetsContext.Remove(widget);
            await _widgetsContext.SaveChangesAsync();
        }
    }
}
