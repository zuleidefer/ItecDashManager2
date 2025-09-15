using AutoMapper;
using ItecDashManager.Domain.Entities.RoleAction;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.RoleAction;
using ItecDashManager.WebApi.ViewModels.RoleAction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleActionController : ControllerBase
{
    private readonly IRoleActionService _roleActionService;
    private readonly IMapper _mapper;

    public RoleActionController(IRoleActionService roleActionService, IMapper mapper)
    {
        _roleActionService = roleActionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var roleActions = await _roleActionService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<RoleActionViewModel>>(roleActions));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var roleAction = await _roleActionService.GetByIdAsync(id);
        if (roleAction == null) return NotFound();
        return Ok(_mapper.Map<RoleActionViewModel>(roleAction));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleActionDTO dto)
    {
        var roleAction = _mapper.Map<RoleAction>(dto);
        await _roleActionService.AddAsync(roleAction);
        return Ok(_mapper.Map<RoleActionViewModel>(roleAction));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RoleActionDTO dto)
    {
        var existing = await _roleActionService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        _mapper.Map(dto, existing);
        await _roleActionService.UpdateAsync(existing);
        return Ok(_mapper.Map<RoleActionViewModel>(existing));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _roleActionService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _roleActionService.DeleteAsync(existing);
        return NoContent();
    }
}