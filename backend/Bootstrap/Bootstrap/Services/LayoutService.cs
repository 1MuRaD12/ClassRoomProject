using Bootstrap.DAL;
using Bootstrap.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bootstrap.services
{
    public class LayoutService
    {
        private readonly AppDbContext context;

        public LayoutService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Settings>> GetSetting()
        {
            List<Settings> settings = await context.settings.ToListAsync();
            return settings;
        }
    }
}
