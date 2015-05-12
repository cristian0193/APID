using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public interface CRUDmaquina
    {
        int insert(Object obj);
        int update(int codigo, String nombre, String referencia, String planta);
        int delete(int codigo);
        Object findById(String id);
    }
}
