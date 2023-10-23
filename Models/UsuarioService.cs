using Biblioteca.Models;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {

                using (BibliotecaContext bc = new BibliotecaContext())
                {
                    return bc.Usuarios.ToList();
                }
        }

        public Usuario Listar(int id){
            using (BibliotecaContext bc = new BibliotecaContext())
                {
                    return bc.Usuarios.Find(id);
                }

        }
        public void IncluirUsuario(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext()){
                bc.Add(u);
                bc.SaveChanges();

            }

        }
        public void EditarUsuario(Usuario u)
        {
            using (BibliotecaContext bc = new BibliotecaContext()){
                Usuario usuarioBD = bc.Usuarios.Find(u.Id);
                usuarioBD.Login = u.Login;
                usuarioBD.Nome = u.Nome;

                if(usuarioBD.Senha != u.Senha){
                   usuarioBD.Senha = Criptografo.TextoCriptografado(u.Senha);
                }
                else{
                usuarioBD.Senha = u.Senha;
                }
                usuarioBD.Tipo = u.Tipo;

                bc.SaveChanges();

            }
        }
        public void ExcluirUsuario(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext()){
                bc.Usuarios.Remove(bc.Usuarios.Find(id));
                bc.SaveChanges();
            }
            
        }
        
    }
}