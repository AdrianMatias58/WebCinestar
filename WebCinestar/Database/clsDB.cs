using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebCinestar.Database
{
    public class clsDB
    {
        // varialbes de entrada
        SqlConnection cn = null;
        SqlCommand cmd = null;
        SqlDataAdapter dt = null;

        //constructor para la conecxion
        public clsDB(IConfiguration conf, string db)
        {
            cn = new SqlConnection(conf.GetConnectionString(db));
            cmd = new SqlCommand("", cn);
            dt = new SqlDataAdapter(cmd);
        }
        //ejecutar sentencia
        internal void Sentencia(string sentencia)
        {
            cmd.CommandText= sentencia;
            cmd.Parameters.Clear();
        }
        //obtener tabla
        internal DataTable getTabla(string tabla)
        {
            DataTable tb = new DataTable();
            dt.Fill(tb);
            return tb;

        }

    }
}
