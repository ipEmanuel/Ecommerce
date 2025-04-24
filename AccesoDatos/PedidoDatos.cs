using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class PedidoDatos
    {
        private readonly string cadenaConexion = "Server=localhost;Database=EcommerceDB;Trusted_Connection=True;";
        public int Guardar(Pedido pedido)
        {
            int idPedido = 0;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                string query = @"INSERT INTO Pedido (FechaPedido, MedioPago, Total)
                                OUTPUT INSERTED.Id
                                VALUES (@FechaPedido, @MedioPago, @Total);";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                comando.Parameters.AddWithValue("@MedioPago", pedido.MedioPago);
                comando.Parameters.AddWithValue("@Total", pedido.Total);

                idPedido = Convert.ToInt32(comando.ExecuteScalar());

                conexion.Close();
            }

            return idPedido;
        }
    }
}
