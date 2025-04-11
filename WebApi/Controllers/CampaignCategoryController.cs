using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignCategoryController : Controller
    {
       private readonly ICategoryService _categoryService;
       private readonly IMapper _mapper;

        
        public CampaignCategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult>GetAll() { 

            var data = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<List<CampaignCategoryDto>>(data));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var data = await _categoryService.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CampaignCategoryDto>(data));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CampaignCategoryCreateDto dto) { 
               
            var category = _mapper.Map<CampaignCategory>(dto);
            await _categoryService.AddAsync(category);
            return Ok(new { message = "Kategori eklendi", id = category.Id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CampaignCategoryUpdateDto dto)
        {
            if(id != dto.Id) return BadRequest("ID uyuşmuyor");
            var category = _mapper.Map<CampaignCategory>(dto);
            await _categoryService.UpdateAsync(category);
            return Ok(new { message = "Kategori güncellendi", id = category.Id });
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _categoryService.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Kategori bulunamadı");
            await _categoryService.DeleteAsync(existing);
            return Ok(new { message = "Kategori silindi" });
        }
    }
}
