using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesProducto
{
    public class Postre : Producto
    {
        #region Atributos
        public enum EPostre { Flan, Helado, Panqueques , Torta };
        public EPostre tipo;

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto establece el precio de los postres en $100.
        /// </summary>
        public Postre() : base()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            this.precio = 100;
            this.tipo = ((Postre.EPostre)rnd.Next(0, 3));
        }

        #endregion

    }
}
