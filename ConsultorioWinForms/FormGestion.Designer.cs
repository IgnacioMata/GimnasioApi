// FormGestion.Designer.cs

namespace ConsultorioWinForms
{
    partial class FormGestion
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstMedicos = new System.Windows.Forms.ListBox();
            this.txtMedicoNombre = new System.Windows.Forms.TextBox();
            this.txtMedicoEspecialidad = new System.Windows.Forms.TextBox();
            this.btnAgregarMedico = new System.Windows.Forms.Button();
            this.btnEliminarMedico = new System.Windows.Forms.Button();
            this.lstPacientes = new System.Windows.Forms.ListBox();
            this.txtPacienteNombre = new System.Windows.Forms.TextBox();
            this.txtPacienteDni = new System.Windows.Forms.TextBox();
            this.btnAgregarPaciente = new System.Windows.Forms.Button();
            this.btnEliminarPaciente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMedicos
            // 
            this.lstMedicos.ItemHeight = 15;
            this.lstMedicos.Location = new System.Drawing.Point(20, 20);
            this.lstMedicos.Name = "lstMedicos";
            this.lstMedicos.Size = new System.Drawing.Size(200, 109);
            this.lstMedicos.TabIndex = 0;
            // 
            // txtMedicoNombre
            // 
            this.txtMedicoNombre.Location = new System.Drawing.Point(20, 150);
            this.txtMedicoNombre.Name = "txtMedicoNombre";
            this.txtMedicoNombre.PlaceholderText = "Nombre del médico";
            this.txtMedicoNombre.Size = new System.Drawing.Size(200, 23);
            this.txtMedicoNombre.TabIndex = 1;
            // 
            // txtMedicoEspecialidad
            // 
            this.txtMedicoEspecialidad.Location = new System.Drawing.Point(20, 180);
            this.txtMedicoEspecialidad.Name = "txtMedicoEspecialidad";
            this.txtMedicoEspecialidad.PlaceholderText = "Especialidad";
            this.txtMedicoEspecialidad.Size = new System.Drawing.Size(200, 23);
            this.txtMedicoEspecialidad.TabIndex = 2;
            // 
            // btnAgregarMedico
            // 
            this.btnAgregarMedico.Location = new System.Drawing.Point(20, 210);
            this.btnAgregarMedico.Name = "btnAgregarMedico";
            this.btnAgregarMedico.Size = new System.Drawing.Size(95, 30);
            this.btnAgregarMedico.TabIndex = 3;
            this.btnAgregarMedico.Text = "Agregar Médico";
            this.btnAgregarMedico.Click += new System.EventHandler(this.btnAgregarMedico_Click);
            // 
            // btnEliminarMedico
            // 
            this.btnEliminarMedico.Location = new System.Drawing.Point(125, 210);
            this.btnEliminarMedico.Name = "btnEliminarMedico";
            this.btnEliminarMedico.Size = new System.Drawing.Size(95, 30);
            this.btnEliminarMedico.TabIndex = 4;
            this.btnEliminarMedico.Text = "Eliminar Médico";
            this.btnEliminarMedico.Click += new System.EventHandler(this.btnEliminarMedico_Click);
            // 
            // lstPacientes
            // 
            this.lstPacientes.ItemHeight = 15;
            this.lstPacientes.Location = new System.Drawing.Point(250, 20);
            this.lstPacientes.Name = "lstPacientes";
            this.lstPacientes.Size = new System.Drawing.Size(200, 109);
            this.lstPacientes.TabIndex = 5;
            // 
            // txtPacienteNombre
            // 
            this.txtPacienteNombre.Location = new System.Drawing.Point(250, 150);
            this.txtPacienteNombre.Name = "txtPacienteNombre";
            this.txtPacienteNombre.PlaceholderText = "Nombre del paciente";
            this.txtPacienteNombre.Size = new System.Drawing.Size(200, 23);
            this.txtPacienteNombre.TabIndex = 6;
            // 
            // txtPacienteDni
            // 
            this.txtPacienteDni.Location = new System.Drawing.Point(250, 180);
            this.txtPacienteDni.Name = "txtPacienteDni";
            this.txtPacienteDni.PlaceholderText = "DNI";
            this.txtPacienteDni.Size = new System.Drawing.Size(200, 23);
            this.txtPacienteDni.TabIndex = 7;
            // 
            // btnAgregarPaciente
            // 
            this.btnAgregarPaciente.Location = new System.Drawing.Point(250, 210);
            this.btnAgregarPaciente.Name = "btnAgregarPaciente";
            this.btnAgregarPaciente.Size = new System.Drawing.Size(95, 30);
            this.btnAgregarPaciente.TabIndex = 8;
            this.btnAgregarPaciente.Text = "Agregar Paciente";
            this.btnAgregarPaciente.Click += new System.EventHandler(this.btnAgregarPaciente_Click);
            // 
            // btnEliminarPaciente
            // 
            this.btnEliminarPaciente.Location = new System.Drawing.Point(355, 210);
            this.btnEliminarPaciente.Name = "btnEliminarPaciente";
            this.btnEliminarPaciente.Size = new System.Drawing.Size(95, 30);
            this.btnEliminarPaciente.TabIndex = 9;
            this.btnEliminarPaciente.Text = "Eliminar Paciente";
            this.btnEliminarPaciente.Click += new System.EventHandler(this.btnEliminarPaciente_Click);
            // 
            // FormGestion
            // 
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 270);
            this.Controls.Add(this.lstMedicos);
            this.Controls.Add(this.txtMedicoNombre);
            this.Controls.Add(this.txtMedicoEspecialidad);
            this.Controls.Add(this.btnAgregarMedico);
            this.Controls.Add(this.btnEliminarMedico);
            this.Controls.Add(this.lstPacientes);
            this.Controls.Add(this.txtPacienteNombre);
            this.Controls.Add(this.txtPacienteDni);
            this.Controls.Add(this.btnAgregarPaciente);
            this.Controls.Add(this.btnEliminarPaciente);
            this.Name = "FormGestion";
            this.Text = "Gestión de Médicos y Pacientes";
            this.Load += new System.EventHandler(this.FormGestion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ListBox lstMedicos;
        private System.Windows.Forms.TextBox txtMedicoNombre;
        private System.Windows.Forms.TextBox txtMedicoEspecialidad;
        private System.Windows.Forms.Button btnAgregarMedico;
        private System.Windows.Forms.Button btnEliminarMedico;
        private System.Windows.Forms.ListBox lstPacientes;
        private System.Windows.Forms.TextBox txtPacienteNombre;
        private System.Windows.Forms.TextBox txtPacienteDni;
        private System.Windows.Forms.Button btnAgregarPaciente;
        private System.Windows.Forms.Button btnEliminarPaciente;
    }
}
