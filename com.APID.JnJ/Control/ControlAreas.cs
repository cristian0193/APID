using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlAreas
    {
        public static int insert( String nombre)
        {
            return new DaoAreas().insert(new VoAreas(nombre));
        }

        public static int delete(int id)
        {
            return new DaoAreas().delete(id);
        }

        public static int update(int codigo, String nombre)
        {
            return new DaoAreas().update(codigo, nombre);
        }

        public static VoAreas findById(String id)
        {
            return new DaoAreas().findById(id) as VoAreas;
        }

        public static VoAreas ConsultarSQL(int id)
        {
            return new DaoAreas().ConsultarSQL(id) as VoAreas;
        }
    }
}
