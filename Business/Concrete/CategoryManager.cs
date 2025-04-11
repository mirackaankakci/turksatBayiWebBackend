using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public Task<List<CampaignCategory>> GetAllAsync() => _categoryDal.GetAllAsync();
        public Task<CampaignCategory> GetByIdAsync(int id) => _categoryDal.GetAsync(p=>p.Id==id);
        public Task AddAsync(CampaignCategory category) => _categoryDal.AddAsync(category);
        public Task UpdateAsync(CampaignCategory category) => _categoryDal.UpdateAsync(category);
        public Task DeleteAsync(CampaignCategory category) => _categoryDal.DeleteAsync(category);
    }
}
