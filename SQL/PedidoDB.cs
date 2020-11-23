using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesProducto;
using Metodos_de_extension;

namespace SQL
{
    public class PedidoDB
    {
        const string STRINGCONNEC = @"Data Source=DESKTOP-9CR275H\SQLEXPRESS;Initial Catalog =Parcial2;Integrated Security = True";
        static SqlConnection sqlConn;
        static SqlCommand command;

        /// <summary>
        /// Contructor estatico, abre la conexion.
        /// </summary>
        static PedidoDB()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = STRINGCONNEC;
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        /// <summary>
        /// Inserta un pedido en la base de datos.
        /// </summary>
        /// <returns>True si inserto, false si no.</returns>
        public static bool InsertarPedido(Pedido nuevoPedido)
        {
            string consulta = " INSERT INTO dbo.pedidos ([Codigo],[Direccion Entrega],[Delivery],[Estado]) VALUES (@codigo ,@direccion,@delivery,@estado)";



            try
            {
                command.CommandText = consulta;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@codigo", nuevoPedido.codigoPedido));
                command.Parameters.Add(new SqlParameter("@direccion", nuevoPedido.direccionDeEntrega.ToString()));
                command.Parameters.Add(new SqlParameter("@delivery", nuevoPedido.delivery.Convert()));
                command.Parameters.Add(new SqlParameter("@estado", nuevoPedido.estadoPedido.ToString()));




                sqlConn.Open();
                int retorno = command.ExecuteNonQuery();

                return retorno != -1;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }




    }
}
