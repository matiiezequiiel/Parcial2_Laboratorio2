using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesProducto;
using Archivos;
using Excepciones;


namespace AguirreMatias2D_2P
{
    [Serializable]
    public static class Local
    {
        #region Atributos

        #endregion
        public static Queue<Pedido> pedidosEnCola;
        public static Queue<Pedido> pedidosEnPreparacion;

        #region Propiedades

        #endregion

        #region Constructores
        static Local()
        {
            pedidosEnCola = new Queue<Pedido>();
            pedidosEnPreparacion = new Queue<Pedido>();
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Genera un nro de pedido ALFABETICO aleatorio de 3 letras.
        /// </summary>
        /// <param name="pedidoRecibido">Pedido recibido.</param>
        public static void GenerarCodigoPedido(Pedido pedidoRecibido)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            string codigo="";

            for (int i = 0; i < 3; i++)
            {
                char randomChar = (char)rnd.Next('A', 'Z');
                codigo += randomChar;
            }

            pedidoRecibido.codigoPedido = codigo;

        }

        /// <summary>
        /// Si el pedido es por delivery, genera un ticket con los datos necesarios para la entrega.
        /// </summary>
        /// <param name="nuevaVenta">Venta.</param>
        public static void GenerarTicketVenta(Pedido nuevaVenta)
        {
            StringBuilder sb = new StringBuilder();
            string ruta = AppDomain.CurrentDomain.BaseDirectory + "PedidosDelivery\\";
            string nombreTicket = nuevaVenta.codigoPedido + ".txt";
            double total = 0;

            Texto auxTexto = new Texto();

            sb.AppendFormat("Fecha: {0}\n", DateTime.Now);
            sb.AppendFormat("Direccion de entrega: {0} \n", nuevaVenta.direccionDeEntrega);

            sb.AppendLine("");
            sb.AppendLine("");
            sb.AppendLine("Lista de productos: ");
            sb.AppendLine("-----------------------------------");

            foreach (Producto item in nuevaVenta.pedido)
            {
                if(item is Hamburguesa)
                {
                    Hamburguesa a =(Hamburguesa) item;
                    sb.AppendFormat("{0,-28}   ${1,-20}\n", a.tipo, a.precio);
                    total = total + a.precio;
                }
                else
                {
                    Postre b = (Postre)item;
                    sb.AppendFormat("{0,-28}   ${1,-20}\n", b.tipo, b.precio);
                    total = total + b.precio;
                }
               
            }


            sb.AppendLine("-----------------------------------");
            sb.AppendFormat("Total:        ${0,20} \n", total.ToString());
            sb.AppendLine("-----------------------------------");
            sb.AppendLine("-----------------------------------");
            sb.AppendFormat("Nro de pedido: {0,20} \n", nuevaVenta.codigoPedido);
            sb.AppendLine("-----------------------------------");

            auxTexto.Guardar(ruta + nombreTicket, sb.ToString());

        }

        /// <summary>
        /// Pone el nuevo pedido en cola.
        /// </summary>
        /// <param name="pedidoRecibido"></param>
        public static void NuevoPedidoEnCola(Pedido pedidoRecibido)
        {
            if(pedidosEnCola.Count < 15)
            {
                pedidosEnCola.Enqueue(pedidoRecibido);
            }
            else
            {
                pedidosEnCola.Enqueue(pedidoRecibido);
                throw new LocalColapsadoException();

            }
           
        }

        /// <summary>
        /// Guarda los pedidos en cola en un xml.
        /// </summary>
        public static void GuardarPedidosPendientes()
        {
            bool hayPedidosPendientes = false;

            foreach (Pedido item in pedidosEnPreparacion)
            {
                if (item.estadoPedido == Pedido.EEstado.Preparacion || item.estadoPedido == Pedido.EEstado.Entrega)
                {
                    hayPedidosPendientes = true;
                    throw new PedidosSinTerminarException();            
                    
                    
                }
                else if(item.estadoPedido == Pedido.EEstado.Entregado)
                {
                    continue;                  
                }
              

                
            }

            if (!hayPedidosPendientes)
            {
                List<Pedido> pedidos = new List<Pedido>(pedidosEnCola);
                string ruta = AppDomain.CurrentDomain.BaseDirectory;

                string nombre = "PedidosPendientes.xml";

                XML<List<Pedido>> pedidosPendientes = new XML<List<Pedido>>();

                pedidosPendientes.Guardar(ruta + nombre, pedidos);
            }


        }



        /// <summary>
        /// Lee los pedidos en cola pendientes de un xml.
        /// </summary>
        /// <returns>True si el archivo tiene datos, false si no.</returns>
        public static bool Leer()
        {

            List<Pedido> listaCargada = new List<Pedido>();
            string archivo = AppDomain.CurrentDomain.BaseDirectory + "PedidosPendientes.xml";
            bool retorno = false;

            XML<List<Pedido>> venta = new XML<List<Pedido>>();


           
            if (venta.Leer(archivo, out listaCargada))
            {
                foreach (Pedido item in listaCargada)
                {
                    pedidosEnCola.Enqueue(item);
                }
               
            }

            if(pedidosEnCola.Count>0)
            {
                retorno = true;
            }
            else
            {
                retorno=false;
            }
                  
            return retorno;

        }



        #endregion

    }
}
