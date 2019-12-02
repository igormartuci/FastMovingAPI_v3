using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.Usuarios
{
    public class UsuarioRepositorio : IRepositorio<Usuario>
    {
        public void Delete(Usuario item)
        {
            UsuarioDAL.DeleteUsuario(item.IDUSU);
        }

        public IEnumerable<Usuario> GetAll()
        {
            return UsuarioDAL.GetUsuarios();            
        }

        public Usuario GetById(int id)
        {
            return UsuarioDAL.GetUsuario(id);
        }

        public void Insert(Usuario item)
        {
            UsuarioDAL.InsertUsuario(item);
        }

        public Usuario Login(Usuario item)
        {
            return UsuarioDAL.PostLogin(item);
        }

        public void Update(Usuario item)
        {
            UsuarioDAL.UpdateUsuario(item);
        }
    }
}