using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Control;
using Dao;

namespace Control
{
   public class ControlEstado
    {
       public static int insert(String nombre, String referencia_estado, String referencia_tipo)
        {
            return new DaoEstado().insert(new VoEstados(nombre, referencia_estado, referencia_tipo));
        }

        public static int update(int codigo, String nombre, String referencia_estado, String referencia_tipo)
        {
            return new DaoEstado().update(codigo, nombre, referencia_estado,referencia_tipo);
        }

        public static int delete(int id)
        {
            return new DaoEstado().delete(id);
        }

        public static VoEstados findById(String id)
        {
            return new DaoEstado().findById(id) as VoEstados;
        }

        public static VoEstados ConsultarSQL(int id)
        {
            return new DaoEstado().ConsultarSQL(id) as VoEstados;
        }
    }
}
