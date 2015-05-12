using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public interface CRUDusuarios
    {
        int insert(Object obj);
        int update(int codigo, String nombre, String apellido, String password, String celular, String correo, String titulo, String Observacion, String area, String cargo, String rol, String estado);
        Object findById(String id);
    }
}
