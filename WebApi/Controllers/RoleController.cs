using AutoMapper;
using ItecDashManager.Domain.Entities.Role;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.Role;
using ItecDashManager.WebApi.ViewModels.Role;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;


    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<RoleViewModel>>(roles));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(_mapper.Map<RoleViewModel>(role));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDTO dto)
        {
            var role = _mapper.Map<Role>(dto);
            await _roleService.AddAsync(role);
            return Ok(_mapper.Map<RoleViewModel>(role));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] RoleDTO dto)
        {
            var existing = await _roleService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);
            await _roleService.UpdateAsync(existing);
            return Ok(_mapper.Map<RoleViewModel>(existing));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var existing = await _roleService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _roleService.DeleteAsync(existing);
            return NoContent();
        }
    }

