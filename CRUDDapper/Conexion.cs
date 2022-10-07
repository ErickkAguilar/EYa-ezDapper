using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDDapper
{
    public class Conexion
    {
        public static string getConexion()
        {
            return "Data Source=.;Initial Catalog=EYañezDapper;User ID=sa;Password=pass@word1";
        }
    }
}
