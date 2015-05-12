using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlRoles
    {
        public static int insert( String nombre)
        {
            return new DaoRoles().insert(new VoRoles(nombre));
        }

        public static int update(int codigo, String nombre)
        {
            return new DaoRoles().update(codigo, nombre);
        }

        public static VoRoles findById(String id)
        {
            return new DaoRoles().findById(id) as VoRoles;
        }

        public static VoRoles ConsultarSQL(int id)
        {
            return new DaoRoles().ConsultarSQL(id) as VoRoles;
        }
    }
}
