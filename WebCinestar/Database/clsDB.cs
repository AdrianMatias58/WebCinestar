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
        internal DataTable getTabla()
        {
            DataTable tb = new DataTable();
            dt.Fill(tb);
            return tb;

        }
        internal string[]? getRegistro()
        {
            DataTable dt = getTabla();
            if (dt.Rows.Count == 0) return null;
            return Array.ConvertAll(dt.Rows[0].ItemArray,
                                    x => x?.ToString()?.Trim() ?? "");
        }

        internal string[][]? getRegistros()
        {
            DataTable dt = getTabla();
            if (dt.Rows.Count == 0) return null;
            int i = 0;
            string[][] registros = new string[dt.Rows.Count][];
            foreach (DataRow dr in dt.Rows)
                registros[i++] = Array.ConvertAll(dr.ItemArray,
                                                  x => x?.ToString()?.Trim() ?? "");
            return registros;
        }

    }
}
