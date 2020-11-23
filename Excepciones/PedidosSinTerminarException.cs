using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class PedidosSinTerminarException : Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public PedidosSinTerminarException() : base("Todavia hay pedidos en preparacion o entrega")
        {

        }
        /// <summary>
        /// Excepcion que controla si el local tiene mas de 10 pedidos en cola.
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public PedidosSinTerminarException(Exception innerException) : base("Todavia hay pedidos en preparacion o entrega<", innerException)
        {

        }

        #endregion
    }
}
