using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace ConsultorioWinForms
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private List<TurnoViewModel> _todosLosTurnos = new();

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7206/api/");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarMedicosAsync();
            await CargarPacientesAsync();
            await CargarTurnosAsync();
            dgvTurnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private async Task CargarTurnosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("turnos");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                _todosLosTurnos = JsonConvert.DeserializeObject<List<TurnoViewModel>>(json);

                dgvTurnos.DataSource = _todosLosTurnos
                    .Select(t => new
                    {
                        t.Id,
                        t.FechaHora,
                        Medico = t.NombreMedico,
                        Especialidad = t.EspecialidadMedico,
                        Paciente = t.NombrePaciente
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var texto = txtBuscar.Text.Trim().ToLower();

            var filtrados = _todosLosTurnos
                .Where(t =>
                    t.NombrePaciente.ToLower().Contains(texto) ||
                    t.NombreMedico.ToLower().Contains(texto))
                .Select(t => new
                {
                    t.Id,
                    t.FechaHora,
                    Medico = t.NombreMedico,
                    Especialidad = t.EspecialidadMedico,
                    Paciente = t.NombrePaciente
                })
                .ToList();

            dgvTurnos.DataSource = filtrados;
        }

        private async Task CargarMedicosAsync()
        {
            var response = await _httpClient.GetAsync("medicos");
            var json = await response.Content.ReadAsStringAsync();
            var medicos = JsonConvert.DeserializeObject<List<Medico>>(json);
            cmbMedicos.DataSource = medicos;
            cmbMedicos.DisplayMember = "Nombre";
            cmbMedicos.ValueMember = "Id";

            cmbMedicos.SelectedIndexChanged += CmbMedicos_SelectedIndexChanged;
            ActualizarEspecialidad();
        }

        private async Task CargarPacientesAsync()
        {
            var response = await _httpClient.GetAsync("pacientes");
            var json = await response.Content.ReadAsStringAsync();
            var pacientes = JsonConvert.DeserializeObject<List<Paciente>>(json);
            cmbPacientes.DataSource = pacientes;
            cmbPacientes.DisplayMember = "Nombre";
            cmbPacientes.ValueMember = "Id";
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevoTurno = new
            {
                FechaHora = dtpFecha.Value,
                MedicoId = (int)cmbMedicos.SelectedValue,
                PacienteId = (int)cmbPacientes.SelectedValue
            };

            var content = new StringContent(JsonConvert.SerializeObject(nuevoTurno), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("turnos", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Turno agregado.");
                await CargarTurnosAsync();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Error al agregar turno:\n" + error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow?.DataBoundItem is not null)
            {
                var idSeleccionado = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["Id"].Value);
                var turnoSeleccionado = _todosLosTurnos.FirstOrDefault(t => t.Id == idSeleccionado);

                if (turnoSeleccionado != null)
                {
                    var turnoEditado = new
                    {
                        Id = turnoSeleccionado.Id,
                        FechaHora = dtpFecha.Value,
                        MedicoId = (int)cmbMedicos.SelectedValue,
                        PacienteId = (int)cmbPacientes.SelectedValue
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(turnoEditado), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"turnos/{turnoSeleccionado.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Turno editado.");
                        await CargarTurnosAsync();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error al editar turno:\n" + error);
                    }
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow?.DataBoundItem is not null)
            {
                var idSeleccionado = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["Id"].Value);

                var confirmar = MessageBox.Show(
                    $"¿Estás seguro de que querés eliminar el turno #{idSeleccionado}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmar == DialogResult.Yes)
                {
                    var response = await _httpClient.DeleteAsync($"turnos/{idSeleccionado}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Turno eliminado correctamente.");
                        await CargarTurnosAsync();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el turno.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccioná un turno para eliminar.");
            }
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            using (var form = new FormGestion())
            {
                form.ShowDialog();
            }

            _ = CargarMedicosAsync();
            _ = CargarPacientesAsync();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarTurnosAsync();
        }

        private void CmbMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEspecialidad();
        }

        private void ActualizarEspecialidad()
        {
            if (cmbMedicos.SelectedItem is Medico medico)
            {
                lblEspecialidadValor.Text = medico.Especialidad;
            }
            else
            {
                lblEspecialidadValor.Text = "";
            }
        }
    }
}
