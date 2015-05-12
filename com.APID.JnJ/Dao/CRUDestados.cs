using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public interface CRUDestados
    {
        int insert(Object obj);
        int update(int codigo, String nombre,String referencia_estado, String referencia_tipo);
        int delete(int id);
        Object findById(String id);
    }
}
