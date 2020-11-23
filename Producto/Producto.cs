using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EntidadesProducto
{
    [Serializable]
    [XmlInclude(typeof(Hamburguesa))]
    [XmlInclude(typeof(Postre))]

    public abstract class Producto
    {
        #region Atributos
        public float precio;
        #endregion

        #region Propiedades

        #endregion

        #region Constructores
        /// <summary>
        /// Constuctor por defecto, inicia el precio en 0.
        /// </summary>
        public Producto()
        {
            this.precio = 0;
        }

        #endregion

        #region Metodos

        #endregion

    }
}
