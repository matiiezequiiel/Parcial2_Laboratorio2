namespace Formulario
{
    partial class PantallaVentas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lsvPedidosEnCola = new System.Windows.Forms.ListView();
            this.columnaNroPedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaDireccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaDelivery = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lsvPedidosEnPreparacion = new System.Windows.Forms.ListView();
            this.columnaPedido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaDireccionPrepara = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnaDel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columanEstado = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnNuevoPedido = new System.Windows.Forms.Button();
            this.lblPendientes = new System.Windows.Forms.Label();
            this.lblEntregados = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsvPedidosEnCola
            // 
            this.lsvPedidosEnCola.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lsvPedidosEnCola.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaNroPedido,
            this.columnaDireccion,
            this.columnaDelivery});
            this.lsvPedidosEnCola.HideSelection = false;
            this.lsvPedidosEnCola.Location = new System.Drawing.Point(33, 93);
            this.lsvPedidosEnCola.Name = "lsvPedidosEnCola";
            this.lsvPedidosEnCola.Size = new System.Drawing.Size(593, 509);
            this.lsvPedidosEnCola.TabIndex = 0;
            this.lsvPedidosEnCola.UseCompatibleStateImageBehavior = false;
            this.lsvPedidosEnCola.View = System.Windows.Forms.View.Details;
            // 
            // columnaNroPedido
            // 
            this.columnaNroPedido.Text = "NRO PEDIDO";
            this.columnaNroPedido.Width = 118;
            // 
            // columnaDireccion
            // 
            this.columnaDireccion.Text = "DIRECCION DE ENTREGA";
            this.columnaDireccion.Width = 251;
            // 
            // columnaDelivery
            // 
            this.columnaDelivery.Text = "DELIVERY";
            this.columnaDelivery.Width = 91;
            // 
            // lsvPedidosEnPreparacion
            // 
            this.lsvPedidosEnPreparacion.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lsvPedidosEnPreparacion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnaPedido,
            this.columnaDireccionPrepara,
            this.columnaDel,
            this.columanEstado});
            this.lsvPedidosEnPreparacion.HideSelection = false;
            this.lsvPedidosEnPreparacion.Location = new System.Drawing.Point(716, 93);
            this.lsvPedidosEnPreparacion.Name = "lsvPedidosEnPreparacion";
            this.lsvPedidosEnPreparacion.Size = new System.Drawing.Size(592, 516);
            this.lsvPedidosEnPreparacion.TabIndex = 1;
            this.lsvPedidosEnPreparacion.UseCompatibleStateImageBehavior = false;
            this.lsvPedidosEnPreparacion.View = System.Windows.Forms.View.Details;
            // 
            // columnaPedido
            // 
            this.columnaPedido.Text = "NRO PEDIDO";
            this.columnaPedido.Width = 123;
            // 
            // columnaDireccionPrepara
            // 
            this.columnaDireccionPrepara.Text = "DIRECCION DE ENTREGA";
            this.columnaDireccionPrepara.Width = 150;
            // 
            // columnaDel
            // 
            this.columnaDel.Text = "DELIVERY";
            this.columnaDel.Width = 83;
            // 
            // columanEstado
            // 
            this.columanEstado.Text = "ESTADO";
            this.columanEstado.Width = 75;
            // 
            // btnNuevoPedido
            // 
            this.btnNuevoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoPedido.Location = new System.Drawing.Point(169, 626);
            this.btnNuevoPedido.Name = "btnNuevoPedido";
            this.btnNuevoPedido.Size = new System.Drawing.Size(278, 37);
            this.btnNuevoPedido.TabIndex = 2;
            this.btnNuevoPedido.Text = "Nuevo Pedido";
            this.btnNuevoPedido.UseVisualStyleBackColor = true;
            this.btnNuevoPedido.Click += new System.EventHandler(this.btnNuevoPedido_Click);
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.92F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendientes.Location = new System.Drawing.Point(115, 23);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(445, 53);
            this.lblPendientes.TabIndex = 3;
            this.lblPendientes.Text = "PEDIDOS EN COLA";
            // 
            // lblEntregados
            // 
            this.lblEntregados.AutoSize = true;
            this.lblEntregados.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.192F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntregados.Location = new System.Drawing.Point(808, 28);
            this.lblEntregados.Name = "lblEntregados";
            this.lblEntregados.Size = new System.Drawing.Size(394, 48);
            this.lblEntregados.TabIndex = 4;
            this.lblEntregados.Text = "EN PREPARACION";
            // 
            // PantallaVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1353, 695);
            this.Controls.Add(this.lblEntregados);
            this.Controls.Add(this.lblPendientes);
            this.Controls.Add(this.btnNuevoPedido);
            this.Controls.Add(this.lsvPedidosEnPreparacion);
            this.Controls.Add(this.lsvPedidosEnCola);
            this.Name = "PantallaVentas";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PantallaVentas_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PantallaVentas_FormClosed);
            this.Load += new System.EventHandler(this.PantallaVentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsvPedidosEnCola;
        private System.Windows.Forms.ListView lsvPedidosEnPreparacion;
        private System.Windows.Forms.Button btnNuevoPedido;
        private System.Windows.Forms.ColumnHeader columnaNroPedido;
        private System.Windows.Forms.ColumnHeader columnaDireccion;
        private System.Windows.Forms.ColumnHeader columnaDelivery;
        private System.Windows.Forms.ColumnHeader columnaPedido;
        private System.Windows.Forms.ColumnHeader columnaDireccionPrepara;
        private System.Windows.Forms.ColumnHeader columnaDel;
        private System.Windows.Forms.ColumnHeader columanEstado;
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.Label lblEntregados;
    }
}

