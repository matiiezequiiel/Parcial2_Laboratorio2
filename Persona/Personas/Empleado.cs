using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LoremNET;

namespace Entidades
{
    public delegate string AvisoEntrega(object o);
    public class Empleado : Persona
    {
        #region Atributos

        public enum EPuesto {Parrilla,Cocinero };
        EPuesto puesto;
        public event AvisoEntrega Aviso;

        #endregion

        #region Constructores
       
        /// <summary>
        /// Constructor de instancia, genera un puesto aleatorio para el empleado.
        /// </summary>
        /// <param name="nombre"></param>
        public Empleado(string nombre) : base(nombre)
        {
            Random rdm = new Random(DateTime.Now.Millisecond);
            this.puesto =(EPuesto) rdm.Next(0, 2);
            Aviso += Local.PedidoEntregadoEnDomicilio;
        }

       


        #endregion

        #region Metodos

        /// <summary>
        /// Se crea un empleado, si la cola de pedidos en cola es mayor a 0 empieza a cocinar.
        /// </summary>
        public static void Cocinar()
        { 
            Empleado a = new Empleado(Lorem.Words(1,true,false));

            if (Local.pedidosEnCola.Count > 0)
            {
                a.prepararProximoPedido();
                Cocinar();
            }

        }


        /// <summary>
        /// Pasa el pedido en cola a la cola de pedidos en preparacion.
        /// </summary>
        public void prepararProximoPedido()
        {
            if (Local.pedidosEnCola.Count > 0)
            {
                Local.pedidosEnPreparacion.Enqueue(Local.pedidosEnCola.Peek());
                this.CocinarPedido(Local.pedidosEnCola.Dequeue());

            }


        }



        /// <summary>
        /// El empleado cocina el pedido, cargando el pedido en la BD, cocinandolo con un tiempo de preparacion aleatorio entre 4 y 10 segundos y creando el ticket si es delivery para el envio con los datos para le entrega. Cuando termina, va a preparar el siguiente pedido.
        /// </summary>
        /// <param name="pedidoPendiente"></param>
        public void CocinarPedido(Pedido pedidoPendiente)
        {
            Random tiempoPreparacion = new Random(DateTime.Now.Millisecond);

            pedidoPendiente.estadoPedido = Pedido.EEstado.Preparacion;
            Thread.Sleep(tiempoPreparacion.Next(4000,10000));


            if (pedidoPendiente.delivery)
            {
                pedidoPendiente.estadoPedido = Pedido.EEstado.Entrega;
                Local.GenerarTicketVenta(pedidoPendiente);
                Thread.Sleep(5000);
                Aviso.Invoke(pedidoPendiente);
                pedidoPendiente.estadoPedido = Pedido.EEstado.Entregado;
               
            }
            else
            {
                pedidoPendiente.estadoPedido = Pedido.EEstado.Entregado;

            }

            PedidoDB.InsertarPedido(pedidoPendiente);

            this.prepararProximoPedido();
            

        }

       

        #endregion
    }
}
