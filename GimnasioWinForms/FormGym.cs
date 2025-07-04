using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GimnasioWinForms
{
    public partial class FormGym : Form
    {
        private readonly HttpClient _httpClient;
        private List<ReservaViewModel> _todasLasReservas = new();

        public FormGym()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7206/api/");
        }

        private async void FormGym_Load(object sender, EventArgs e)
        {
            await CargarEntrenadoresAsync();
            await CargarSociosAsync();
            await CargarReservasAsync();
        }

        private async Task CargarReservasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("reservas");

                if (response.IsSuccessStatusCode &&
                    response.Content.Headers.ContentType?.MediaType == "application/json")
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var reservas = JsonConvert.DeserializeObject<List<ReservaViewModel>>(json);

                    _todasLasReservas = reservas;

                    dgvReservas.DataSource = reservas
                        .Select(r => new
                        {
                            r.Id,
                            r.FechaHora,
                            Entrenador = r.NombreEntrenador,
                            Especialidad = r.EspecialidadEntrenador,
                            Socio = r.NombreSocio
                        })
                        .ToList();
                }
                else
                {
                    string error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("⚠️ El servidor respondió con un error:\n\n" + error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("🛑 Error al cargar reservas:\n\n" + ex.Message);
            }
        }

        private async Task CargarEntrenadoresAsync()
        {
            var response = await _httpClient.GetAsync("entrenadores");
            var json = await response.Content.ReadAsStringAsync();
            var entrenadores = JsonConvert.DeserializeObject<List<Entrenador>>(json);
            cmbEntrenadores.DataSource = entrenadores;
            cmbEntrenadores.DisplayMember = "Nombre";
            cmbEntrenadores.ValueMember = "Id";

            cmbEntrenadores.SelectedIndexChanged += CmbEntrenadores_SelectedIndexChanged;
            ActualizarEspecialidad();
        }

        private async Task CargarSociosAsync()
        {
            var response = await _httpClient.GetAsync("socios");
            var json = await response.Content.ReadAsStringAsync();
            var socios = JsonConvert.DeserializeObject<List<Socio>>(json);
            cmbSocios.DataSource = socios;
            cmbSocios.DisplayMember = "Nombre";
            cmbSocios.ValueMember = "Id";
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            var nuevaReserva = new
            {
                FechaHora = dtpFecha.Value,
                EntrenadorId = (int)cmbEntrenadores.SelectedValue,
                SocioId = (int)cmbSocios.SelectedValue
            };

            var content = new StringContent(JsonConvert.SerializeObject(nuevaReserva), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("reservas", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("✅ Reserva agregada.");
                await CargarReservasAsync();
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("❌ Error al agregar reserva:\n" + error);
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow?.DataBoundItem is not null)
            {
                var idSeleccionado = Convert.ToInt32(dgvReservas.CurrentRow.Cells["Id"].Value);
                var reservaSeleccionada = _todasLasReservas.FirstOrDefault(r => r.Id == idSeleccionado);

                if (reservaSeleccionada != null)
                {
                    var reservaEditada = new
                    {
                        Id = reservaSeleccionada.Id,
                        FechaHora = dtpFecha.Value,
                        EntrenadorId = (int)cmbEntrenadores.SelectedValue,
                        SocioId = (int)cmbSocios.SelectedValue
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(reservaEditada), Encoding.UTF8, "application/json");
                    var response = await _httpClient.PutAsync($"reservas/{reservaSeleccionada.Id}", content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("📝 Reserva editada.");
                        await CargarReservasAsync();
                    }
                    else
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("❌ Error al editar reserva:\n" + error);
                    }
                }
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReservas.CurrentRow?.DataBoundItem is not null)
            {
                var idSeleccionado = Convert.ToInt32(dgvReservas.CurrentRow.Cells["Id"].Value);

                var confirmar = MessageBox.Show(
                    $"¿Seguro que querés eliminar la reserva #{idSeleccionado}?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmar == DialogResult.Yes)
                {
                    var response = await _httpClient.DeleteAsync($"reservas/{idSeleccionado}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("🗑 Reserva eliminada correctamente.");
                        await CargarReservasAsync();
                    }
                    else
                    {
                        MessageBox.Show("❌ Error al eliminar la reserva.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccioná una reserva antes de eliminar.");
            }
        }

        private void btnGestionar_Click(object sender, EventArgs e)
        {
            using (var form = new FormGestion())
            {
                form.ShowDialog();
            }

            _ = CargarEntrenadoresAsync();
            _ = CargarSociosAsync();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            await CargarReservasAsync();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var texto = txtBuscar.Text.Trim().ToLower();

            var filtrados = _todasLasReservas
                .Where(r =>
                    r.NombreSocio.ToLower().Contains(texto) ||
                    r.NombreEntrenador.ToLower().Contains(texto))
                .Select(r => new
                {
                    r.Id,
                    r.FechaHora,
                    Entrenador = r.NombreEntrenador,
                    Especialidad = r.EspecialidadEntrenador,
                    Socio = r.NombreSocio
                })
                .ToList();

            dgvReservas.DataSource = filtrados;
        }

        private void CmbEntrenadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarEspecialidad();
        }

        private void ActualizarEspecialidad()
        {
            if (cmbEntrenadores.SelectedItem is Entrenador entrenador)
            {
                lblEspecialidadValor.Text = entrenador.Especialidad;
            }
            else
            {
                lblEspecialidadValor.Text = "";
            }
        }
    }
}
