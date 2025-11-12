namespace MercaditoMovil.Views.WinForms
{
    partial class FrmCarrito
    {
        private ReaLTaiizor.Controls.MaterialComboBox comboFerias;
        private ReaLTaiizor.Controls.MaterialListBox listaProductos;
        private ReaLTaiizor.Controls.MaterialListBox listaCarrito;
        private ReaLTaiizor.Controls.MaterialButton btnAgregar;
        private ReaLTaiizor.Controls.MaterialButton btnQuitar;
        private ReaLTaiizor.Controls.MaterialButton btnFinalizar;

        private void InitializeComponent()
        {
            this.comboFerias = new ReaLTaiizor.Controls.MaterialComboBox();
            this.listaProductos = new ReaLTaiizor.Controls.MaterialListBox();
            this.listaCarrito = new ReaLTaiizor.Controls.MaterialListBox();
            this.btnAgregar = new ReaLTaiizor.Controls.MaterialButton();
            this.btnQuitar = new ReaLTaiizor.Controls.MaterialButton();
            this.btnFinalizar = new ReaLTaiizor.Controls.MaterialButton();
            this.SuspendLayout();

            // 
            // comboFerias
            // 
            this.comboFerias.AutoResize = false;
            this.comboFerias.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            this.comboFerias.Depth = 0;
            this.comboFerias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboFerias.DropDownHeight = 174;
            this.comboFerias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFerias.Font = new System.Drawing.Font("Roboto Medium", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.comboFerias.ForeColor = System.Drawing.Color.FromArgb(222, 0, 0, 0);
            this.comboFerias.FormattingEnabled = true;
            this.comboFerias.Hint = "Seleccionar feria";
            this.comboFerias.IntegralHeight = false;
            this.comboFerias.ItemHeight = 43;
            this.comboFerias.Location = new System.Drawing.Point(30, 90);
            this.comboFerias.MaxDropDownItems = 4;
            this.comboFerias.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            this.comboFerias.Name = "comboFerias";
            this.comboFerias.Size = new System.Drawing.Size(300, 49);
            this.comboFerias.StartIndex = 0;

            // 
            // listaProductos
            // 
            this.listaProductos.BackColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.listaProductos.BorderColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.listaProductos.Depth = 0;
            this.listaProductos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.listaProductos.ForeColor = System.Drawing.Color.White;
            this.listaProductos.Location = new System.Drawing.Point(30, 160);
            this.listaProductos.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.listaProductos.Name = "listaProductos";
            this.listaProductos.SelectedIndex = -1;
            this.listaProductos.Size = new System.Drawing.Size(300, 260);

            // 
            // listaCarrito
            // 
            this.listaCarrito.BackColor = System.Drawing.Color.FromArgb(50, 50, 60);
            this.listaCarrito.BorderColor = System.Drawing.Color.FromArgb(80, 80, 90);
            this.listaCarrito.Depth = 0;
            this.listaCarrito.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.listaCarrito.ForeColor = System.Drawing.Color.White;
            this.listaCarrito.Location = new System.Drawing.Point(430, 160);
            this.listaCarrito.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.listaCarrito.Name = "listaCarrito";
            this.listaCarrito.SelectedIndex = -1;
            this.listaCarrito.Size = new System.Drawing.Size(300, 260);

            // 
            // btnAgregar
            // 
            this.btnAgregar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnAgregar.Depth = 0;
            this.btnAgregar.HighEmphasis = true;
            this.btnAgregar.Icon = null;
            this.btnAgregar.Location = new System.Drawing.Point(350, 210);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAgregar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnAgregar.Size = new System.Drawing.Size(60, 36);
            this.btnAgregar.Text = "→";
            this.btnAgregar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnAgregar.UseAccentColor = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);

            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnQuitar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnQuitar.Depth = 0;
            this.btnQuitar.HighEmphasis = true;
            this.btnQuitar.Icon = null;
            this.btnQuitar.Location = new System.Drawing.Point(350, 270);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnQuitar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnQuitar.Size = new System.Drawing.Size(60, 36);
            this.btnQuitar.Text = "←";
            this.btnQuitar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnQuitar.UseAccentColor = false;
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);

            // 
            // btnFinalizar
            // 
            this.btnFinalizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnFinalizar.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnFinalizar.Depth = 0;
            this.btnFinalizar.HighEmphasis = true;
            this.btnFinalizar.Icon = null;
            this.btnFinalizar.Location = new System.Drawing.Point(500, 450);
            this.btnFinalizar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFinalizar.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnFinalizar.Size = new System.Drawing.Size(150, 36);
            this.btnFinalizar.Text = "Finalizar Compra";
            this.btnFinalizar.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnFinalizar.UseAccentColor = true;
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.BtnFinalizar_Click);

            // 
            // FrmCarrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 520);
            this.Controls.Add(this.comboFerias);
            this.Controls.Add(this.listaProductos);
            this.Controls.Add(this.listaCarrito);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnFinalizar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCarrito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🛒 Carrito de Compras - Mercadito Móvil";
            this.Load += new System.EventHandler(this.FrmCarrito_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
