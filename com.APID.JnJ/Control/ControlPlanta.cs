using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
    public class ControlPlanta
    {
        public static int insert( String nombre, String aplicado)
        {
            return new DaoPlanta().insert(new VoPlanta(nombre, aplicado));
        }

        public static int update(int codigo, String nombre, String aplicado)
        {
            return new DaoPlanta().update(codigo, nombre, aplicado);
        }

        public static int delete(int codigo)
        {
            return new DaoPlanta().delete(codigo);
        }

        public static VoPlanta findById(String id)
        {
            return new DaoPlanta().findById(id) as VoPlanta;
        }

        public static VoPlanta ConsultarSQL(int id)
        {
            return new DaoPlanta().ConsultarSQL(id) as VoPlanta;
        }
    }
}
