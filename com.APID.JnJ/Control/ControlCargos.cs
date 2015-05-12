using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlCargos
    {
        public static int insert( String nombre)
        {
            return new DaoCargos().insert(new VoCargos(nombre));
        }

        public static int delete(int id)
        {
            return new DaoCargos().delete(id);
        }

        public static int update(int codigo, String nombre)
        {
            return new DaoCargos().update(codigo, nombre);
        }

        public static VoCargos findById(String id)
        {
            return new DaoCargos().findById(id) as VoCargos;
        }

        public static VoCargos ConsultarSQL(int id)
        {
            return new DaoCargos().ConsultarSQL(id) as VoCargos;
        }
    }
}
