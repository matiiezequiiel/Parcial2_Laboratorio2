using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LoremNET;

namespace Entidades 
{
    delegate void NuevoPedido(Pedido a);
    public class Cliente : Persona
    {
        #region Atributos

        string direccionDeEntrega;
        Pedido pedidoRealizado;
        event NuevoPedido pedidoNuevo;

        #endregion

        #region Propiedades

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        public Cliente(string nombre,string direccion) : base(nombre) 
        {
            pedidoRealizado = new Pedido();
            this.direccionDeEntrega = direccion;
            pedidoNuevo += Local.GenerarCodigoPedido;
            pedidoNuevo += Local.NuevoPedidoEnCola; 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Se crea un cliente con datos aleatorios y se realiza un nuevo pedido.
        /// </summary>
        public static void NuevoPedido()
        {
            Cliente a = new Cliente(Lorem.Words(1,true,false),Lorem.Words(1, true, false) + " " + Lorem.Number(0,9999).ToString() );

            a.RealizarPedido();

        }



        /// <summary>
        /// Se cargan los datos del nuevo pedido y se dispara el evento "Pedido nuevo" que genera el nro de ticket y pone en cola el pedido en el local.
        /// </summary>
        /// <returns></returns>
        public Pedido RealizarPedido()
        {

            Random rnd = new Random(DateTime.Now.Millisecond);
            Hamburguesa a = new Hamburguesa();
            Postre b = new Postre();

            this.pedidoRealizado.direccionDeEntrega = this.direccionDeEntrega;
            this.pedidoRealizado.delivery = rnd.Next(0, 2) == 1 ? true : false;
            this.pedidoRealizado.pedido.Add(a);
            this.pedidoRealizado.pedido.Add(b);
            pedidoNuevo.Invoke(this.pedidoRealizado);
            

            return this.pedidoRealizado;
              
        }


        #endregion
    }
}
