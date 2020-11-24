using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Threading;

namespace Test_Unitario
{
    [TestClass]
    public class Test
    {

        #region TEST UNITARIOS
        /// <summary>
        /// Metodo de test que comprueba cuando el local tiene mas de 15 pedidos en cola y genera una excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(LocalColapsadoException))]
        public void Test_LocalColapsado()
        {
            Cliente a = new Cliente("A", "b");

            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();

          
        }

        /// <summary>
        /// Metodo de test que valida que al cerrar la aplicacion no haya pedidos en preparacion y genera una excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(PedidosSinTerminarException))]
        public void Test_PedidosSinTerminar()
        {
            Local.pedidosEnCola.Clear();
            Local.pedidosEnPreparacion.Clear();
            Cliente a = new Cliente("A", "B");
            Empleado b = new Empleado("B");
            Thread hiloEmpleado = new Thread(Empleado.Cocinar);

            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
            a.RealizarPedido();
           
            hiloEmpleado.Start();
            Thread.Sleep(2000);

            Local.GuardarPedidosPendientes();
        }
        
        [TestMethod]

        public void Test_ValorNull()
        {

            Assert.IsNotNull(Local.pedidosEnCola);
            Assert.IsNotNull(Local.pedidosEnCola);

        }

        /// <summary>
        /// Metodo de test que comprueba problemas con archivos genera una excepcion.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void Test_ArchivoError()
        {
            string rutaInvalida = "rutainvalida";
            XML<Pedido> datos = new XML<Pedido>();
            Pedido clPrueba = new Pedido();




            datos.Leer(rutaInvalida, out clPrueba);



        }
        
        #endregion
    }
}
