namespace MercaditoMovil.Views.WinForms
{
    partial class FrmCarrito
    {
        private ReaLTaiizor.Controls.MaterialComboBox ComboFerias;
        private ReaLTaiizor.Controls.MaterialListBox ListaProductos;
        private ReaLTaiizor.Controls.MaterialListBox ListaCarrito;
        private ReaLTaiizor.Controls.MaterialButton BtnAgregar;
        private ReaLTaiizor.Controls.MaterialButton BtnQuitar;
        private ReaLTaiizor.Controls.MaterialButton BtnFinalizar;

        /// <summary>
        /// Limpieza de recursos
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboFerias = new ReaLTaiizor.Controls.MaterialComboBox();
            this.ListaProductos = new ReaLTaiizor.Controls.MaterialListBox();
            this.ListaCarrito = new ReaLTaiizor.Controls.MaterialListBox();
            this.BtnAgregar = new ReaLTaiizor.Controls.MaterialButton();
            this.BtnQuitar = new ReaLTaiizor.Controls.MaterialButton();
            this.BtnFinalizar = new ReaLTaiizor.Controls.MaterialButton();

            this.SuspendLayout();

            // ============================================================
            // ComboFerias
            // ============================================================
            this.ComboFerias.AutoResize = false;
            this.ComboFerias.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.ComboFerias.Depth = 0;
            this.ComboFerias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ComboFerias.DropDownHeight = 174;
            this.ComboFerias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboFerias.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.ComboFerias.ForeColor = System.Drawing.Color.Black;
            this.ComboFerias.Hint = "Seleccionar feria";
            this.ComboFerias.IntegralHeight = false;
            this.ComboFerias.ItemHeight = 43;
            this.ComboFerias.Location = new System.Drawing.Point(25, 100);
            this.ComboFerias.MaxDropDownItems = 4;
            this.ComboFerias.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.ComboFerias.Size = new System.Drawing.Size(320, 49);

            // ============================================================
            // ListaProductos
            // ============================================================
            this.ListaProductos.BackColor = System.Drawing.Color.White;
            this.ListaProductos.BorderColor = System.Drawing.Color.LightGray;
            this.ListaProductos.Depth = 0;
            this.ListaProductos.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ListaProductos.Location = new System.Drawing.Point(25, 170);
            this.ListaProductos.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.ListaProductos.Size = new System.Drawing.Size(320, 330);

            // ============================================================
            // ListaCarrito
            // ============================================================
            this.ListaCarrito.BackColor = System.Drawing.Color.White;
            this.ListaCarrito.BorderColor = System.Drawing.Color.LightGray;
            this.ListaCarrito.Depth = 0;
            this.ListaCarrito.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.ListaCarrito.Location = new System.Drawing.Point(430, 170);
            this.ListaCarrito.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.ListaCarrito.Size = new System.Drawing.Size(320, 330);

            // ============================================================
            // BtnAgregar
            // ============================================================
            this.BtnAgregar.AutoSize = false;
            this.BtnAgregar.Text = "Agregar →";
            this.BtnAgregar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnAgregar.Location = new System.Drawing.Point(360, 240);
            this.BtnAgregar.Size = new System.Drawing.Size(60, 45);
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);

            // ============================================================
            // BtnQuitar
            // ============================================================
            this.BtnQuitar.AutoSize = false;
            this.BtnQuitar.Text = "← Quitar";
            this.BtnQuitar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnQuitar.Location = new System.Drawing.Point(360, 300);
            this.BtnQuitar.Size = new System.Drawing.Size(60, 45);
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);

            // ============================================================
            // BtnFinalizar
            // ============================================================
            this.BtnFinalizar.AutoSize = false;
            this.BtnFinalizar.Text = "Finalizar compra";
            this.BtnFinalizar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.BtnFinalizar.Location = new System.Drawing.Point(430, 520);
            this.BtnFinalizar.Size = new System.Drawing.Size(200, 50);
            this.BtnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);

            // ============================================================
            // FrmCarrito
            // ============================================================
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.ComboFerias);
            this.Controls.Add(this.ListaProductos);
            this.Controls.Add(this.ListaCarrito);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnQuitar);
            this.Controls.Add(this.BtnFinalizar);

            this.Name = "FrmCarrito";
            this.Text = "Carrito de Compras";
            this.Load += new System.EventHandler(this.FrmCarrito_Load);

            this.ResumeLayout(false);
        }
    }
}

