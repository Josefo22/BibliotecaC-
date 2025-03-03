using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase2.Clases
{
    internal class cConexion
    {
        static private string CadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Desktop\POO\Clase2\bdBiblioteca.mdf;Integrated Security=True;Connect Timeout=30";
        //Definir una variable para conectarse a la base de datos
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);

        //metodo para abrir la base de datos
        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed) Conexion.Open();
            return Conexion;
        }

        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open) Conexion.Close();
            return Conexion;
        }
    }
}
