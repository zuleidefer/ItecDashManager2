using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;
using ItecDashManager.Domain.Entities.Dashboard;
using FluentValidation;

namespace ItecDashManager.Domain.Entities.Dashboard;

    public class DashboardValidator : FluentValidation.AbstractValidator<Dashboard>
    {
        public DashboardValidator()
        {
           RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres");

           RuleFor(x => x.Url)
            .NotEmpty().WithMessage("A URL é obrigatória")
            .MaximumLength(200).WithMessage("A URL deve ter no máximo 200 caracteres");
        }
    }

