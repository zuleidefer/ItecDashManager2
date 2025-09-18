using AutoMapper;
using ItecDashManager.Domain.Entities.Actions;
using ItecDashManager.Domain.Interfaces.ServiceInterfaces;
using ItecDashManager.WebApi.DTO.Action;
using ItecDashManager.WebApi.ViewModels.Action;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItecDashManager.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActionController : ControllerBase
{
    private readonly IActionService _actionService;
    private readonly IMapper _mapper;

    public ActionController(IActionService actionService, IMapper mapper)
    {
        _actionService = actionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var actions = await _actionService.GetAllAsync();
        return Ok(_mapper.Map<IEnumerable<ApplicatonActionViewModel>>(actions));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var action = await _actionService.GetByIdAsync(id);
        if (action == null) return NotFound();
        return Ok(_mapper.Map<ApplicatonActionViewModel>(action));
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ApplicationActionDTO dto)
    {
        var action = _mapper.Map<ApplicationAction>(dto);
        await _actionService.AddAsync(action);
        return Ok(_mapper.Map<ApplicatonActionViewModel>(action));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ApplicationActionDTO dto)
    {
        var existing = await _actionService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        _mapper.Map(dto, existing);
        await _actionService.UpdateAsync(existing);
        return Ok(_mapper.Map<ApplicatonActionViewModel>(existing));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var existing = await _actionService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        await _actionService.DeleteAsync(existing);
        return NoContent();
    }
}