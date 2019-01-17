using Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Transversal.Authenticacion
{
    public interface IUserService
    {
        Task<UsuarioPerfilDTO> AuthenticateAsync(string username, string password);
    }
}
