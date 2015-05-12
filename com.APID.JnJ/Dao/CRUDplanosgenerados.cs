using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public interface CRUDplanosgenerados
    {
        int insert(Object obj);
        int update(int codigo, String Descripcion, String usuario, String elaborador, String Razoncreacion, String Ruta);
        int delete(int codigo);
        Object findById(String id);
    }
}
