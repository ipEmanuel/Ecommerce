using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class ProductoDatos
    {
        private readonly string cadenaConexion = "Server=localhost;Database=EcommerceDB;Trusted_Connection=True;";

        public List<Producto> Listar()
        {
            List<Producto> Lista = new List<Producto>();

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                string query = "SELECT Id, Nombre, Descripcion, Precio, Stock, ImagenUrl FROM Producto";

                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto producto = new Producto
                    {
                        Id = (int)lector["Id"],
                        Nombre = lector["Nombre"].ToString(),
                        Descripcion = lector["Descripcion"].ToString(),
                        Precio = (decimal)lector["Precio"],
                        Stock = (int)lector["Stock"],
                        ImagenUrl = lector["ImagenUrl"].ToString()
                    };

                    Lista.Add(producto);
                }
                lector.Close();
            }
            return Lista;

        }
   
    
    }
}
