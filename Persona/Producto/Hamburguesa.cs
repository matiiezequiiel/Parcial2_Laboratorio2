using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{ 
    public class Hamburguesa : Producto
    {
        #region Atributos

        public enum EHamburguesa { Simple,Doble,Triple};
        public EHamburguesa tipo;

        #endregion

        #region Propiedades

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor que establece el precio de las hamburguesas en $500.
        /// </summary>
        public Hamburguesa()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            this.precio = 100;
            this.tipo = ((EHamburguesa)rnd.Next(0, 3));
        }
        

        #endregion

 
    }
}
