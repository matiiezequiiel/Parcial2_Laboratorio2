using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AguirreMatias2D_2P;
using EntidadesProducto;
using Persona;
using Metodos_de_extension;
using Excepciones;


namespace Formulario
{
    delegate void miDelegado();
    public partial class PantallaVentas : Form
    {
        List<Thread> hiloEmpleadosA = new List<Thread>();
        Thread hiloEmpleados = new Thread(Empleado.Cocinar);
        Thread hiloActualizarListas;
        event miDelegado PedidosPendientes;

        public PantallaVentas()
        {
            InitializeComponent();
            this.hiloActualizarListas = new Thread(new ParameterizedThreadStart(RefrescarListas));
        }

        private void PantallaVentas_Load(object sender, EventArgs e)
        {
            hiloActualizarListas.Start(1000);
            PedidosPendientes += EmpezarACocinar;
         
            hiloEmpleadosA.Add(new Thread(Empleado.Cocinar));
            if(Local.Leer())
            {
                PedidosPendientes.Invoke();
            }


        }

        public void RefrescarListas(object segundos)
        {
            Queue<Pedido> pedidosEnCola = Local.pedidosEnCola;
            Queue<Pedido> pedidosEnPreparacion = Local.pedidosEnPreparacion;
            Queue<Pedido> pedidosANotfiicar = new Queue<Pedido>();

            try
            {
                if (this.lsvPedidosEnCola.InvokeRequired)
                {
                    this.lsvPedidosEnCola.BeginInvoke((MethodInvoker)delegate () {
                        this.lsvPedidosEnCola.Items.Clear();
                        foreach (Pedido item in pedidosEnCola)
                        {

                            ListViewItem aux = new ListViewItem(item.codigoPedido);
                            aux.BackColor = Color.Red;
                            aux.SubItems.Add(item.direccionDeEntrega);
                            aux.SubItems.Add(item.delivery.Convert());
                            lsvPedidosEnCola.Items.Add(aux);


                        }
                    });
                }
                else
                {
                    this.lsvPedidosEnCola.Items.Clear();
                    foreach (Pedido item in pedidosEnCola)
                    {

                        ListViewItem aux = new ListViewItem(item.codigoPedido);
                        aux.BackColor = Color.Red;
                        aux.SubItems.Add(item.direccionDeEntrega);
                        aux.SubItems.Add(item.delivery.Convert());
                        lsvPedidosEnCola.Items.Add(aux);

                    }
                }



                if (this.lsvPedidosEnPreparacion.InvokeRequired)
                {
                    this.lsvPedidosEnPreparacion.BeginInvoke((MethodInvoker)delegate () {
                        this.lsvPedidosEnPreparacion.Items.Clear();
                        foreach (Pedido item in pedidosEnPreparacion)
                        {
                            ListViewItem aux = new ListViewItem(item.codigoPedido);
                            switch (item.estadoPedido)
                            {
                                case Pedido.EEstado.Entregado:
                                    aux.BackColor = Color.Green;
                                    if(item.delivery)
                                    {
                                        if (!pedidosANotfiicar.Contains(item)) 
                                            pedidosANotfiicar.Enqueue(item);
                                    }
                                break;
                                case Pedido.EEstado.Preparacion:
                                    aux.BackColor = Color.Cyan;
                                    break;
                                case Pedido.EEstado.Entrega:
                                    aux.BackColor = Color.Yellow;
                                break;
                            }
                       
                            aux.SubItems.Add(item.direccionDeEntrega);
                            aux.SubItems.Add(item.delivery.Convert());
                            aux.SubItems.Add(item.estadoPedido.ToString());
                            lsvPedidosEnPreparacion.Items.Add(aux);


                        }
                        if(pedidosANotfiicar.Count>0)
                        {
                            Pedido p = pedidosANotfiicar.Peek();

                            MessageBox.Show("El pedido " + p.codigoPedido + " fue entregado satisfactoriamente en el domicilio.");
                        }
                       

                        //foreach (Pedido item in pedidosANotfiicar)
                        //{
                        //    MessageBox.Show("El pedido " + item.codigoPedido + " fue entregado satisfactoriamente en el domicilio.");
                        //    break;
                        //}
                        //pedidosANotfiicar.Clear();
                    });
                }
                else
                {
                    this.lsvPedidosEnPreparacion.Items.Clear();
                    foreach (Pedido item in pedidosEnPreparacion)
                    {

                        ListViewItem aux = new ListViewItem(item.codigoPedido);
                        switch (item.estadoPedido)
                        {
                            case Pedido.EEstado.Entregado:
                                aux.BackColor = Color.Green;
                                if (item.delivery)
                                {
                                    if(!pedidosANotfiicar.Contains(item))
                                    pedidosANotfiicar.Enqueue(item);
                                }
                                break;
                            case Pedido.EEstado.Preparacion:
                                aux.BackColor = Color.Cyan;
                                break;
                            case Pedido.EEstado.Entrega:
                                aux.BackColor = Color.Yellow;
                                break;
                        }

                        aux.SubItems.Add(item.direccionDeEntrega);
                        aux.SubItems.Add((item.delivery.Convert()));
                        aux.SubItems.Add(item.estadoPedido.ToString());
                        lsvPedidosEnPreparacion.Items.Add(aux);

                    }

                    //foreach (Pedido item in pedidosANotfiicar)
                    //{
                    //    MessageBox.Show("El pedido " + item.codigoPedido + " fue entregado satisfactoriamente en el domicilio.");
                    //    break;
                    //}

                    //pedidosANotfiicar.Clear();
                }


            }
            catch
            {

            }
           

            Thread.Sleep((int)segundos);
            RefrescarListas(segundos);
        }
        
        
      

        private void btnNuevoPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente.NuevoPedido();
                

            }
            catch (LocalColapsadoException ex)
            {
                MessageBox.Show(ex.Message + ",se agregara a un empleado para no demorar los pedidos.");
                hiloEmpleadosA.Add(new Thread(Empleado.Cocinar));
               
            }
            finally
            {
                PedidosPendientes.Invoke();

            }


        }

        private void EmpezarACocinar()
        {
          
            for (int i = 0; i < hiloEmpleadosA.Count; i++)
            {
               
                if (hiloEmpleadosA[i].ThreadState == ThreadState.Unstarted)
                {
                    hiloEmpleadosA[i].Start();
                    break;
                }
                else if (hiloEmpleadosA[i].ThreadState == ThreadState.Stopped)
                {
                    hiloEmpleadosA[i] = new Thread(Empleado.Cocinar);
                    hiloEmpleadosA[i].Start();
                    break;

                }           

            }

        }

        private void PantallaVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Local.GuardarPedidosPendientes();
            }
            catch(PedidosSinTerminarException ex)
            {
                if (MessageBox.Show(ex.Message + "\nDesea salir igualmente? Los pedidos en preparacion se perderan.", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Local.pedidosEnPreparacion.Clear();
                    Local.GuardarPedidosPendientes();                 
                    this.Close();
                }
                else
                {
                    e.Cancel = true;
                }
                 
                
            }
           
           
        }

        private void PantallaVentas_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Thread item in hiloEmpleadosA)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }

            }
        }
    }
}
