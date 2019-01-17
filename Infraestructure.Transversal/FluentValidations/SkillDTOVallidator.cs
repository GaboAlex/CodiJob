using Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class SkillDTOValidator : AbstractValidator<SkillDTO>
    {
        public SkillDTOValidator()
        {
            RuleFor(x => x.SkillNom).NotEmpty();
            RuleFor(x => x.SkillNom).Length(5, 100);
        }
    }
}
