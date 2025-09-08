using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItecDashManager.Domain.Entities.User;
using FluentValidation;

namespace ItecDashManager.Domain.Entities.UserDashboard;

    public class UserDashboardValidator : FluentValidation.AbstractValidator<UserDashboard>
    {
        public UserDashboardValidator() 
        {
            RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("O usuário é obrigatório");

            RuleFor(x => x.DashboardId)
                .NotEmpty().WithMessage("O dashboard é obrigatório");
        }
    }

