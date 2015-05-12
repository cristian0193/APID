using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
    public class ControlMaquinas
    {
       public static int insert(String nombre, String indicativo, String planta)
        {
            return new DaoMaquina().insert(new VoMaquinas(nombre, indicativo, planta));
        }

       public static int update(int codigo,String nombre, String indicativo, String planta)
        {
            return new DaoMaquina().update(codigo,nombre, indicativo, planta);
        }

       public static int delete(int codigo)
       {
           return new DaoMaquina().delete(codigo);
       }

       public static VoMaquinas findById(String id)
        {
            return new DaoMaquina().findById(id) as VoMaquinas;
        }

       public static VoMaquinas ConsultarSQL(int id)
        {
            return new DaoMaquina().ConsultarSQL(id) as VoMaquinas;
        }
    }
}
