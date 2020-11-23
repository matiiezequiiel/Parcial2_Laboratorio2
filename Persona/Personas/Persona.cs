using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        #region Atributos

        string nombre;

        #endregion

        #region Propiedades

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de instancia.
        /// </summary>
        /// <param name="nombre">Nombre de la persona.</param>
        public Persona(string nombre)
        {
            this.nombre = nombre;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
