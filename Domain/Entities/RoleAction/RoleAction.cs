using ItecDashManager.Domain.Entities.Roles;
using ItecDashManager.Domain.Entities.Actions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Options;

namespace ItecDashManager.Domain.Entities.RoleAction;

public class RoleAction
{
    [Key]
    public Guid Id { get; set; }

    [ForeignKey("Role")]
    public Guid RoleId { get; set; }
    public Roles.Role Role { get; set; } = default!;

    [ForeignKey("Action")]
    public Guid ActionId { get; set; }
    public Actions.ApplicationAction Action { get; set; } = default!;
}