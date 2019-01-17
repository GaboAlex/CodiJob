
using Application.DTOs.CustomDTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator() 
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.UserName).Length(5, 12);
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Password).Length(6, 16);
        }
    }
}
