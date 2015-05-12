using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
    public class ControlTiposPlanos
    {
        public static int insert( String nombre, String aplicado)
        {
            return new DaoTipoPlanos().insert(new VoTiposPlano(nombre, aplicado));
        }

        public static int update(int codigo, String nombre, String aplicado)
        {
            return new DaoTipoPlanos().update(codigo, nombre, aplicado);
        }

        public static int delete(int codigo)
        {
            return new DaoTipoPlanos().delete(codigo);
        }

        public static VoTiposPlano findById(String id)
        {
            return new DaoTipoPlanos().findById(id) as VoTiposPlano;
        }

        public static VoTiposPlano ConsultarSQL(int id)
        {
            return new DaoTipoPlanos().ConsultarSQL(id) as VoTiposPlano;
        }
    }
}
