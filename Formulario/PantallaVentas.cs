using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Entidades;


namespace Formulario
{
    delegate void miDelegado();
    public partial class PantallaVentas : Form 
    {
        List<Thread> hiloEmpleadosA = new List<Thread>();
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
            if (Local.Leer())
            {
                PedidosPendientes.Invoke();
            }

        }

        public void SeguirPedidosEntrega()
        {
           
            Queue<Pedido> auxPedido=new Queue<Pedido>();

            foreach (Pedido item in Local.pedidosEnPreparacion)
            {
                if(item.estadoPedido == Pedido.EEstado.Entregado && item.delivery )
                {
                    if(!auxPedido.Contains(item))
                    auxPedido.Enqueue(item);
                }
            }
            
            if (auxPedido.Count > 0)
            {
                Pedido p = auxPedido.Dequeue();
                MessageBox.Show("El pedido " +p.codigoPedido + " fue entregado satisfactoriamente en el domicilio.");
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

                }


            }
            catch(Exception)
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
