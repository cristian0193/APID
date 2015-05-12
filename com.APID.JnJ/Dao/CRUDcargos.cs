using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Dao
{
    public interface CRUDcargos
    {
        int insert(Object obj);
        int update(int codigo, String nombre);
        int delete(int id);
        Object findById(String id);
    }
}
