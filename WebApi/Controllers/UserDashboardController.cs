using AutoMapper;
using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.Domain.Interfaces.RepositoryInterfaces;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.UserDashboard;
using ItecDashManager.WebApi.ViewModels.UserDashboard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UserDashboardController : ControllerBase
{
            private readonly IUserDashboardService _userDashboardService;
            private readonly IMapper _mapper;
            
            public UserDashboardController(IUserDashboardService userDashboardService, IMapper mapper)
            {
                _userDashboardService = userDashboardService;
                _mapper = mapper;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _userDashboardService.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<UserDashboardViewModel>>(result));
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(Guid id)
            {
                var entity = await _userDashboardService.GetByIdAsync(id);
                if (entity == null) return NotFound();
                return Ok(_mapper.Map<UserDashboardViewModel>(entity));
            }

            [HttpPost]
            public async Task<IActionResult> Create([FromBody] UserDashboardDTO dto)
            {
                if (dto.UserId == Guid.Empty || dto.DashboardId == Guid.Empty)
                {
                    return BadRequest(new { message = "Os IDs de Usuário e Dashboard são obrigatórios." });
                }
                var entity = _mapper.Map<UserDashboard>(dto);
                await _userDashboardService.AddAsync(entity);
                return Ok(_mapper.Map<UserDashboardViewModel>(entity));
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(Guid id, [FromBody] UserDashboardDTO dto)
            {
                var existing = await _userDashboardService.GetByIdAsync(id);
                if (existing == null) return NotFound();

                _mapper.Map(dto, existing);
                await _userDashboardService.UpdateAsync(existing);
                return Ok(_mapper.Map<UserDashboardViewModel>(existing));
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(Guid id)
            {
                var existing = await _userDashboardService.GetByIdAsync(id);
                if (existing == null) return NotFound();

                await _userDashboardService.DeleteAsync(existing);
                return NoContent();
            }
        }
     

