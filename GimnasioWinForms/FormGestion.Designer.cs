// FormGestion.Designer.cs

namespace GimnasioWinForms
{
    partial class FormGestion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstEntrenadores = new System.Windows.Forms.ListBox();
            this.txtEntrenadorNombre = new System.Windows.Forms.TextBox();
            this.txtEntrenadorEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAgregarEntrenador = new System.Windows.Forms.Button();
            this.btnEliminarEntrenador = new System.Windows.Forms.Button();
            this.lstSocios = new System.Windows.Forms.ListBox();
            this.txtSocioNombre = new System.Windows.Forms.TextBox();
            this.txtSocioDni = new System.Windows.Forms.TextBox();
            this.btnAgregarSocio = new System.Windows.Forms.Button();
            this.btnEliminarSocio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstEntrenadores
            // 
            this.lstEntrenadores.ItemHeight = 15;
            this.lstEntrenadores.Location = new System.Drawing.Point(20, 20);
            this.lstEntrenadores.Name = "lstEntrenadores";
            this.lstEntrenadores.Size = new System.Drawing.Size(200, 109);
            this.lstEntrenadores.TabIndex = 0;
            // 
            // txtEntrenadorNombre
            // 
            this.txtEntrenadorNombre.Location = new System.Drawing.Point(20, 150);
            this.txtEntrenadorNombre.Name = "txtEntrenadorNombre";
            this.txtEntrenadorNombre.PlaceholderText = "Nombre del entrenador";
            this.txtEntrenadorNombre.Size = new System.Drawing.Size(200, 23);
            this.txtEntrenadorNombre.TabIndex = 1;
            // 
            // txtEntrenadorEspecialidad
            // 
            this.txtEntrenadorEspecialidad.Location = new System.Drawing.Point(20, 180);
            this.txtEntrenadorEspecialidad.Name = "txtEntrenadorEspecialidad";
            this.txtEntrenadorEspecialidad.PlaceholderText = "Especialidad";
            this.txtEntrenadorEspecialidad.Size = new System.Drawing.Size(200, 23);
            this.txtEntrenadorEspecialidad.TabIndex = 2;
            // 
            // btnAgregarEntrenador
            // 
            this.btnAgregarEntrenador.Location = new System.Drawing.Point(20, 210);
            this.btnAgregarEntrenador.Name = "btnAgregarEntrenador";
            this.btnAgregarEntrenador.Size = new System.Drawing.Size(95, 30);
            this.btnAgregarEntrenador.TabIndex = 3;
            this.btnAgregarEntrenador.Text = "Agregar";
            this.btnAgregarEntrenador.Click += new System.EventHandler(this.btnAgregarEntrenador_Click);
            // 
            // btnEliminarEntrenador
            // 
            this.btnEliminarEntrenador.Location = new System.Drawing.Point(125, 210);
            this.btnEliminarEntrenador.Name = "btnEliminarEntrenador";
            this.btnEliminarEntrenador.Size = new System.Drawing.Size(95, 30);
            this.btnEliminarEntrenador.TabIndex = 4;
            this.btnEliminarEntrenador.Text = "Eliminar";
            this.btnEliminarEntrenador.Click += new System.EventHandler(this.btnEliminarEntrenador_Click);
            // 
            // lstSocios
            // 
            this.lstSocios.ItemHeight = 15;
            this.lstSocios.Location = new System.Drawing.Point(250, 20);
            this.lstSocios.Name = "lstSocios";
            this.lstSocios.Size = new System.Drawing.Size(200, 109);
            this.lstSocios.TabIndex = 5;
            // 
            // txtSocioNombre
            // 
            this.txtSocioNombre.Location = new System.Drawing.Point(250, 150);
            this.txtSocioNombre.Name = "txtSocioNombre";
            this.txtSocioNombre.PlaceholderText = "Nombre del socio";
            this.txtSocioNombre.Size = new System.Drawing.Size(200, 23);
            this.txtSocioNombre.TabIndex = 6;
            // 
            // txtSocioDni
            // 
            this.txtSocioDni.Location = new System.Drawing.Point(250, 180);
            this.txtSocioDni.Name = "txtSocioDni";
            this.txtSocioDni.PlaceholderText = "DNI";
            this.txtSocioDni.Size = new System.Drawing.Size(200, 23);
            this.txtSocioDni.TabIndex = 7;
            // 
            // btnAgregarSocio
            // 
            this.btnAgregarSocio.Location = new System.Drawing.Point(250, 210);
            this.btnAgregarSocio.Name = "btnAgregarSocio";
            this.btnAgregarSocio.Size = new System.Drawing.Size(95, 30);
            this.btnAgregarSocio.TabIndex = 8;
            this.btnAgregarSocio.Text = "Agregar";
            this.btnAgregarSocio.Click += new System.EventHandler(this.btnAgregarSocio_Click);
            // 
            // btnEliminarSocio
            // 
            this.btnEliminarSocio.Location = new System.Drawing.Point(355, 210);
            this.btnEliminarSocio.Name = "btnEliminarSocio";
            this.btnEliminarSocio.Size = new System.Drawing.Size(95, 30);
            this.btnEliminarSocio.TabIndex = 9;
            this.btnEliminarSocio.Text = "Eliminar";
            this.btnEliminarSocio.Click += new System.EventHandler(this.btnEliminarSocio_Click);
            // 
            // FormGestion
            // 
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.lstEntrenadores);
            this.Controls.Add(this.txtEntrenadorNombre);
            this.Controls.Add(this.txtEntrenadorEspecialidad);
            this.Controls.Add(this.btnAgregarEntrenador);
            this.Controls.Add(this.btnEliminarEntrenador);
            this.Controls.Add(this.lstSocios);
            this.Controls.Add(this.txtSocioNombre);
            this.Controls.Add(this.txtSocioDni);
            this.Controls.Add(this.btnAgregarSocio);
            this.Controls.Add(this.btnEliminarSocio);
            this.Name = "FormGestion";
            this.Text = "Gestión de Entrenadores y Socios";
            this.Load += new System.EventHandler(this.FormGestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListBox lstEntrenadores;
        private System.Windows.Forms.TextBox txtEntrenadorNombre;
        private System.Windows.Forms.TextBox txtEntrenadorEspecialidad;
        private System.Windows.Forms.Button btnAgregarEntrenador;
        private System.Windows.Forms.Button btnEliminarEntrenador;
        private System.Windows.Forms.ListBox lstSocios;
        private System.Windows.Forms.TextBox txtSocioNombre;
        private System.Windows.Forms.TextBox txtSocioDni;
        private System.Windows.Forms.Button btnAgregarSocio;
        private System.Windows.Forms.Button btnEliminarSocio;
    }
}
