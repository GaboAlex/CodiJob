using Application;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure.Transversal.FluentValidations
{
    public class UsuarioPerfilDTOValidator : AbstractValidator<UsuarioPerfilDTO>
    {
        public UsuarioPerfilDTOValidator()
        {
            RuleFor(x => x.UsuperDesc).NotEmpty();
            RuleFor(x => x.UsuperDesc).Length(10, 200);
            RuleFor(x => x.UsuperGit).NotEmpty();
            RuleFor(x => x.UsuperGit).Length(10, 100);
            RuleFor(x => x.UsuperBlog).NotEmpty();
            RuleFor(x => x.UsuperBlog).Length(10, 100);
            RuleFor(x => x.UsuperWeb).NotEmpty();
            RuleFor(x => x.UsuperWeb).Length(10, 200);
        }
    }
}
