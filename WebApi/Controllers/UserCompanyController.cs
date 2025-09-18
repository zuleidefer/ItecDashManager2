using AutoMapper;
using ItecDashManager.Domain.Entities.Company;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.Company;
using ItecDashManager.WebApi.DTO.UserCompany;
using ItecDashManager.WebApi.ViewModels.Company;
using ItecDashManager.WebApi.ViewModels.UserCompany;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;

    [ApiController]
    [Route("api/user/[controller]")]
    public class UserCompanyController : ControllerBase
    {
        private readonly IUserCompanyService _userCompanyService;
        private readonly IMapper _mapper;

        public UserCompanyController(IUserCompanyService userCompanyService, IMapper mapper)
        {
            _userCompanyService = userCompanyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _userCompanyService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserCompanyViewModel>>(companies));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userCompany = await _userCompanyService.GetByIdAsync(id);
            if (userCompany == null) return NotFound();
            return Ok(_mapper.Map<CompanyViewModel>(userCompany));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCompanyDTO dto)
        {
            var userCompany = _mapper.Map<UserCompany>(dto);
            await _userCompanyService.AddAsync(userCompany);
            return Ok(_mapper.Map<UserCompanyViewModel>(userCompany));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserCompanyDTO dto)
        {
            var existing = await _userCompanyService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _userCompanyService.UpdateAsync(existing);
            return Ok(_mapper.Map<UserCompanyViewModel>(existing));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _userCompanyService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _userCompanyService.DeleteAsync(existing);
            return NoContent();
        }
    }

