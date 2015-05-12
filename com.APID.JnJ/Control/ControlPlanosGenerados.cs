using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlPlanosGenerados
    {
       public static int insert(String codigogenerado, String consecutivo, String Revision, String Descripcion, String Razoncreacion, String Ruta, String usuario, String estado,String elaborador)
        {
            return new DaoPlanosGenerados().insert(new VoPlanosGenerados(codigogenerado, consecutivo, Revision, Descripcion, Razoncreacion, Ruta, usuario, estado, elaborador));
        }

       public static int delete(int codigo)
       {
           return new DaoPlanosGenerados().delete(codigo);
       }

       public static int update(int codigo, String Descripcion, String usuario, String elaborador, String Razoncreacion, String Ruta)
        {
            return new DaoPlanosGenerados().update(codigo, Descripcion, usuario, elaborador, Razoncreacion, Ruta);
        }

        public static VoPlanosGenerados findById(String id)
        {
            return new DaoPlanosGenerados().findById(id) as VoPlanosGenerados;
        }

        public static VoPlanosGenerados ConsultarSQL(int id)
        {
            return new DaoPlanosGenerados().ConsultarSQL(id) as VoPlanosGenerados;
        }
    }
}
