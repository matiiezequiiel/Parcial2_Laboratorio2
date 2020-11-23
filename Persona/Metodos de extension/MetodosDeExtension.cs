using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodosDeExtension
    {
        /// <summary>
        /// Convierte un tipo bool en "Si" o "No" para ser mostrado en las listas.
        /// </summary>
        /// <param name="valor">Valor Booleano.</param>
        /// <returns>Valor string.</returns>
        public static string Convert(this bool valor)
        {
            string retorno;
            switch (valor)
            {
                case true:
                    retorno = "Si";
                    break;
                case false:
                    retorno = "No";
                    break;
                default:
                    retorno = "Si";
                    break;
            }

            return retorno;
        }
    }
}
