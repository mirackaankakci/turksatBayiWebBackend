using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Task<List<CampaignCategory>> GetAllAsync();
        Task<CampaignCategory> GetByIdAsync(int id);
        Task AddAsync(CampaignCategory category);
        Task UpdateAsync(CampaignCategory category);
        Task DeleteAsync(CampaignCategory category);
    }
}
