using Login.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Login.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateSessionUser(UsuarioModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoveSessionUser()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");

        }

        public UsuarioModel SearchSessionUser()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }
    }
}
