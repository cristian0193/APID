using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlUsuario
    {
       public static int insert(int codigo, String nombre, String apellido, String password, String celular, String correo, String titulo, String Observacion, String area, String cargo, String rol, String estado)
        {
            return new DaoUsuarios().insert(new VoUsuarios( codigo,nombre,  apellido, password,  celular, correo, titulo, Observacion, area, cargo, rol, estado));
        }

        public static int update(int codigo, String nombre, String apellido, String password, String celular, String correo, String titulo, String Observacion, String area, String cargo, String rol, String estado)
        {
            return new DaoUsuarios().update( codigo,  nombre,  apellido, password,  celular, correo, titulo, Observacion, area, cargo, rol, estado);
        }

        public static VoUsuarios findById(String id)
        {
            return new DaoUsuarios().findById(id) as VoUsuarios;
        }

        public static VoUsuarios ConsultarSQL(int id)
        {
            return new DaoUsuarios().ConsultarSQL(id) as VoUsuarios;
        }
    }
}
