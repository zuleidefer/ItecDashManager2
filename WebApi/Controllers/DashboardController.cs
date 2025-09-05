using AutoMapper;
using ItecDashManager.Domain.Entities.Dashboard;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.Dashboard;
using ItecDashManager.WebApi.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;

namespace ItecDashManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IDashboardService _dashboardService;
    private readonly IMapper _mapper;

    public DashboardController(IDashboardService dashboardService, IMapper mapper)
    {
        _dashboardService = dashboardService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dashboards = await _dashboardService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<DashboardViewModel>>(dashboards));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dashboard = await _dashboardService.GetByIdAsync(id);
        if (dashboard == null)
            return NotFound();

        return Ok(_mapper.Map<DashboardViewModel>(dashboard));

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DashboardDTO dto)
    {
        var dashboard = _mapper.Map<Dashboard>(dto);
        await _dashboardService.AddAsync(dashboard);
        return Ok(_mapper.Map<DashboardViewModel>(dashboard));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DashboardDTO dto)
    {
        var existing = await _dashboardService.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        _mapper.Map(dto, existing);
        await _dashboardService.UpdateAsync(existing);

        return Ok(_mapper.Map<DashboardViewModel>(existing));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _dashboardService.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _dashboardService.DeleteAsync(existing);
        return NoContent();
    }
}



