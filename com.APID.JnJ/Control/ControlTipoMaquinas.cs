using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
    public class ControlTipoMaquinas
    {
       public static int insert(String nombre, String indicativo, String planta)
        {
            return new DaoTipoMaquina().insert(new VoTipoMaquinas(nombre, indicativo, planta));
        }

       public static int update(int codigo,String nombre, String indicativo, String planta)
        {
            return new DaoTipoMaquina().update(codigo, nombre, indicativo, planta);
        }

       public static int delete(int codigo)
       {
           return new DaoTipoMaquina().delete(codigo);
       }

       public static VoTipoMaquinas findById(String id)
        {
            return new DaoTipoMaquina().findById(id) as VoTipoMaquinas;
        }

       public static VoTipoMaquinas ConsultarSQL(int id)
        {
            return new DaoTipoMaquina().ConsultarSQL(id) as VoTipoMaquinas;
        }
    }
}
