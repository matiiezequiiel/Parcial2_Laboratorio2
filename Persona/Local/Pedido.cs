using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades

{
    [Serializable]
    public class Pedido 
    {
        
        #region Atributos

        public string codigoPedido;
        public List<Producto> pedido;
        public string direccionDeEntrega;
        public bool delivery;
        public enum EEstado { Cola,Preparacion,Entrega,Entregado };
        public EEstado estadoPedido;

        #endregion

        #region Propiedades

        #endregion

        #region Constructores
        public Pedido()
        {
            pedido = new List<Producto>();            
            estadoPedido = EEstado.Cola;
        }

        
        #endregion

        #region Metodos

        #endregion
    }
}
