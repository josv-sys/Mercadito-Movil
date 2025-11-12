namespace MercaditoMovil.Views.WinForms
{
    partial class FrmLogin
    {
        private ReaLTaiizor.Controls.MaterialTextBoxEdit TxtCorreo;
        private ReaLTaiizor.Controls.MaterialTextBoxEdit TxtContrasena;
        private ReaLTaiizor.Controls.MaterialButton BtnIngresar;
        private ReaLTaiizor.Controls.MaterialLabel LblTitulo;

        private void InitializeComponent()
        {
            this.TxtCorreo = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.TxtContrasena = new ReaLTaiizor.Controls.MaterialTextBoxEdit();
            this.BtnIngresar = new ReaLTaiizor.Controls.MaterialButton();
            this.LblTitulo = new ReaLTaiizor.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.Text = "Inicio de Sesión";
            this.LblTitulo.Location = new System.Drawing.Point(140, 70);
            this.LblTitulo.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.LblTitulo.AutoSize = true;
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Hint = "Correo electrónico";
            this.TxtCorreo.Location = new System.Drawing.Point(90, 130);
            this.TxtCorreo.Size = new System.Drawing.Size(300, 50);
            // 
            // TxtContrasena
            // 
            this.TxtContrasena.Hint = "Contraseña";
            this.TxtContrasena.Location = new System.Drawing.Point(90, 200);
            this.TxtContrasena.Size = new System.Drawing.Size(300, 50);
            this.TxtContrasena.UseSystemPasswordChar = true;
            // 
            // BtnIngresar
            // 
            this.BtnIngresar.Text = "Ingresar";
            this.BtnIngresar.Location = new System.Drawing.Point(160, 280);
            this.BtnIngresar.Size = new System.Drawing.Size(160, 45);
            this.BtnIngresar.Click += new System.EventHandler(this.BtnIngresar_Click);
            // 
            // FrmLogin
            // 
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.TxtCorreo);
            this.Controls.Add(this.TxtContrasena);
            this.Controls.Add(this.BtnIngresar);
            this.Name = "FrmLogin";
            this.Text = "Mercadito Móvil - Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
