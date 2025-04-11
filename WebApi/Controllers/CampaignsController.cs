using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampaignsController : Controller
    {
        private readonly ICampaignService _campaignService;
        private readonly IMapper _mapper;
        public CampaignsController(ICampaignService campaignService, IMapper mapper){

            _campaignService = campaignService;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var campaign = await _campaignService.GetByIdAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            var dtoCampaign = _mapper.Map<CampaignDto>(campaign);
            return dtoCampaign != null ? Ok(dtoCampaign) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campaigns = await _campaignService.GetAllAsync();
            var dtosCampaign = _mapper.Map<List<CampaignDto>>(campaigns);
            return Ok(dtosCampaign);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CampaignCreateDto dto)
        {
            var campaign = _mapper.Map<Campaign>(dto);
            campaign.CreatedAt = DateTime.UtcNow;
            campaign.UpdatedAt = DateTime.UtcNow;
            campaign.IsActive = true;

            await _campaignService.AddAsync(campaign);
            return Ok(new { message = "Kampanya eklendi", id = campaign.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CampaignUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID uyuşmuyor");

            // 1. Veritabanından mevcut kampanyayı getir
            var existing = await _campaignService.GetByIdAsync(id);
            if (existing == null)
                return NotFound("Kampanya bulunamadı");

            // 2. Güncel verileri set et
            existing.Name = dto.Name;
            existing.UpdatedAt = DateTime.UtcNow;
            existing.Features = dto.Features
                .Select(f => new CampaignFeature { FeatureText = f }).ToList();
            existing.PricingOptions = dto.PricingOptions
                .Select(p => new CampaignPricingOption
                {
                    ContractMonths = p.ContractMonths,
                    PriceMonthly = p.PriceMonthly,
                    PriceMonthlyAfter = p.PriceMonthlyAfter
                }).ToList();

            await _campaignService.UpdateAsync(existing);

            return Ok(new { message = "Kampanya güncellendi" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var campaign = await _campaignService.GetByIdAsync(id);
            if (campaign == null)
                return NotFound("Kampanya bulunamadı");

            await _campaignService.DeleteAsync(campaign);
            return Ok(new { message = "Kampanya silindi" });
        }
    }
}
