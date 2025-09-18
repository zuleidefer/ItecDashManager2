using AutoMapper;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.Company;
using ItecDashManager.WebApi.ViewModels.Company;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CompanyViewModel>>(companies));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(_mapper.Map<CompanyViewModel>(company));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyDTO dto)
        {
            var company = _mapper.Map<Company>(dto);
            await _companyService.AddAsync(company);
            return Ok(_mapper.Map<CompanyViewModel>(company));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CompanyDTO dto)
        {
            var existing = await _companyService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _companyService.UpdateAsync(existing);
            return Ok(_mapper.Map<CompanyViewModel>(existing));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _companyService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _companyService.DeleteAsync(existing);
            return NoContent();
        }
    }
           

