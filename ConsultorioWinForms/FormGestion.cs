using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConsultorioWinForms
{
    public partial class FormGestion : Form
    {
        private readonly HttpClient _httpClient;

        public FormGestion()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7206/api/");
        }

        private async void FormGestion_Load(object sender, EventArgs e)
        {
            await CargarMedicos();
            await CargarPacientes();
        }

        private async Task CargarMedicos()
        {
            var response = await _httpClient.GetAsync("medicos");
            var json = await response.Content.ReadAsStringAsync();
            var medicos = JsonConvert.DeserializeObject<List<Medico>>(json);
            lstMedicos.DataSource = medicos;
            lstMedicos.DisplayMember = "Nombre";
            lstMedicos.ValueMember = "Id";
        }

        private async Task CargarPacientes()
        {
            var response = await _httpClient.GetAsync("pacientes");
            var json = await response.Content.ReadAsStringAsync();
            var pacientes = JsonConvert.DeserializeObject<List<Paciente>>(json);
            lstPacientes.DataSource = pacientes;
            lstPacientes.DisplayMember = "Nombre";
            lstPacientes.ValueMember = "Id";
        }

        private async void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            var medico = new
            {
                Nombre = txtMedicoNombre.Text,
                Especialidad = txtMedicoEspecialidad.Text
            };

            var content = new StringContent(JsonConvert.SerializeObject(medico), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("medicos", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Médico agregado.");
                await CargarMedicos();
            }
            else
            {
                MessageBox.Show("Error al agregar médico.");
            }
        }

        private async void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            if (lstMedicos.SelectedItem is Medico medico)
            {
                var response = await _httpClient.DeleteAsync($"medicos/{medico.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Médico eliminado.");
                    await CargarMedicos();
                }
                else
                {
                    MessageBox.Show("Error al eliminar médico.");
                }
            }
        }

        private async void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            var paciente = new
            {
                Nombre = txtPacienteNombre.Text,
                Dni = txtPacienteDni.Text
            };

            var content = new StringContent(JsonConvert.SerializeObject(paciente), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("pacientes", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Paciente agregado.");
                await CargarPacientes();
            }
            else
            {
                MessageBox.Show("Error al agregar paciente.");
            }
        }

        private async void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            if (lstPacientes.SelectedItem is Paciente paciente)
            {
                var response = await _httpClient.DeleteAsync($"pacientes/{paciente.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Paciente eliminado.");
                    await CargarPacientes();
                }
                else
                {
                    MessageBox.Show("Error al eliminar paciente.");
                }
            }
        }
    }
}
