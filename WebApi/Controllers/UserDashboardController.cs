using AutoMapper;
using ItecDashManager.Domain.Entities.UserDashboard;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.UserDashboard;
using ItecDashManager.WebApi.ViewModels.UserDashboard;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;

    [ApiController]
    [Route("api/[controller]")]
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
     

