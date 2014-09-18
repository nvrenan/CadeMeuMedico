using System;
using System.Linq;
using System.Web.Security;
using CadeMeuMedico.Models;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            string SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            try
            {
                using (var db = new EntidadesCadeMeuMedicoBD())
                {
                    var QueryAutenticaUsuarios = db.Usuarios.Where(x => x.Login == Login && x.Senha == Senha).
                                                             SingleOrDefault();
                    if (QueryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    //RepositorioCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.IDUsuario);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}