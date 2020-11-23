using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class XML<T> : IArchivo<T> where T : class, new()
    {
        /// <summary>
        /// Guarda en formato serializado .xml cualquier tipo de clase.
        /// </summary>
        /// <param name="archivo"> Parth del archivo</param>
        /// <param name="datos"> Cualquier tipo de dato a guardar</param>
        /// <returns></returns>

        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            try
            {
                ser.Serialize(writer, datos);
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
        /// Le� archivo serializado .xml y retorna el tipo de clase en salida por parametro.
        /// </summary>
        /// <param name="archivo"> Path del archivo </param>
        /// <param name="datos"> Salida de cualquier tipo de dato leido </param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = new XmlTextReader(archivo);
            bool retorno = false;

         

            try
            {
                datos = (T)ser.Deserialize(reader);
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
