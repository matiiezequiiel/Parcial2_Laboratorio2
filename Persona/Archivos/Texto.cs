using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda cadena de texto en un archivo y retorna si lo logro con true
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Cadena de texto a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter writer = new StreamWriter(archivo);
            bool retorno = false;

            try
            {
                writer.Write(datos);
                retorno = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                writer.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Recibe el path del archivo y retorna si lo logro con true, redirecciona la informacion del archivo en una salida por parametro
        /// </summary>
        /// <param name="archivo"> Path del archivo</param>
        /// <param name="datos"> Salida del archivo</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader reader = new StreamReader(archivo);
            bool retorno = false;

            try
            {
                datos = reader.ReadToEnd();
                retorno = true;
            }
            catch (Exception e)
            {

                throw new ArchivosException(e);
            }
            finally
            {
                reader.Close();
            }

            return retorno;

        }
    }
}
