using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test_Unitario
{
    [TestClass]
    public class Test
    {

        #region TEST UNITARIOS
        /// <summary>
        /// Metodo de test que comprueba compra repetida y genera una excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(VentaDuplicadaException))]
        public void Test_VentaDuplicada()
        {


            Venta venta1 = new Venta(new List<Producto>(), 1, new Cliente(), new Empleado());
            Venta venta2 = new Venta(new List<Producto>(), 1, new Cliente(), new Empleado());

            Comercio c = new Comercio();

            c += venta1;
            c += venta2;



        }

        /// <summary>
        /// Metodo de test que valida rango de DNI dependiendo de su nacionalidad y genera una excepcion
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void Test_DNINacionalidadInvalida()
        {
            string DNI_Invalido = "90000000";   // 90.000.000 A 99.999.999 | DNI FUERA DE RANGO EN ALUMNO a1

            Cliente a1 = new Cliente("Diego", "Maradona", DNI_Invalido, Persona.ESexo.Masculino, Persona.ENacionalidad.Argentino);
            Cliente a2 = new Cliente("Federico", "Ramirez", "95000000", Persona.ESexo.Masculino, Persona.ENacionalidad.Argentino);
            Comercio u = new Comercio();

            u += a1;
            u += a2;

        }

        /// <summary>
        /// Metodo de test que valida el formato numerico para la carga del DNI
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void Test_DNIValorNumerico()
        {
            string DNI_MalFormato = "90000D00";

            Empleado a1 = new Empleado("Diego", "Maradona", DNI_MalFormato, Persona.ESexo.Masculino, Persona.ENacionalidad.Argentino, 1, 50, DateTime.Now);
            Comercio u = new Comercio();

            u += a1;

        }

        /// <summary>
        /// Metodo de test que valida un tpo de clase si su valor es NULL
        /// </summary>
        [TestMethod]

        public void Test_ValorNull()
        {
            Comercio u = new Comercio();

            Assert.IsNotNull(u.Clientes);
            Assert.IsNotNull(u.Empleados);
            Assert.IsNotNull(u.Inventario);
            Assert.IsNotNull(u.Ventas);

        }

        /// <summary>
        /// Metodo de test que comprueba problemas con archivos genera una excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void Test_ArchivoError()
        {
            string rutaInvalida = "rutainvalida";
            XML<Cliente> datos = new XML<Cliente>();
            Cliente clPrueba = new Cliente();




            datos.Leer(rutaInvalida, out clPrueba);



        }
        #endregion
    }
}
