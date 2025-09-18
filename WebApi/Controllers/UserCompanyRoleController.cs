using AutoMapper;
using ItecDashManager.Domain.Entities.UserCompany;
using ItecDashManager.Domain.Entities.UserCompanyRole;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.UserCompany;
using ItecDashManager.WebApi.DTO.UserCompanyRole;
using ItecDashManager.WebApi.ViewModels.Company;
using ItecDashManager.WebApi.ViewModels.UserCompany;
using ItecDashManager.WebApi.ViewModels.UserCompanyRole;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;

    public class UserCompanyRoleController : ControllerBase
    {
        private readonly IUserCompanyRoleService _userCompanyRoleService;
        private readonly IMapper _mapper;

        public UserCompanyRoleController(IUserCompanyRoleService userCompanyRoleService, IMapper mapper)
        {
            _userCompanyRoleService = userCompanyRoleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _userCompanyRoleService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserCompanyRoleViewModel>>(companies));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var userCompanyRole = await _userCompanyRoleService.GetByIdAsync(id);
            if (userCompanyRole == null) return NotFound();
            return Ok(_mapper.Map<CompanyViewModel>(userCompanyRole));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCompanyRoleDTO dto)
        {
            var userCompanyRole = _mapper.Map<UserCompanyRole>(dto);
            await _userCompanyRoleService.AddAsync(userCompanyRole);
            return Ok(_mapper.Map<UserCompanyRoleViewModel>(userCompanyRole));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserCompanyRoleDTO dto)
        {
            var existing = await _userCompanyRoleService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _userCompanyRoleService.UpdateAsync(existing);
            return Ok(_mapper.Map<UserCompanyRoleViewModel>(existing));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _userCompanyRoleService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _userCompanyRoleService.DeleteAsync(existing);
            return NoContent();
        }
}

