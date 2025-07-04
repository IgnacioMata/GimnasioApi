using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace GimnasioWinForms
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
            await CargarEntrenadores();
            await CargarSocios();
        }

        private async Task CargarEntrenadores()
        {
            var response = await _httpClient.GetAsync("entrenadores");
            var json = await response.Content.ReadAsStringAsync();
            var entrenadores = JsonConvert.DeserializeObject<List<Entrenador>>(json);
            lstEntrenadores.DataSource = entrenadores;
            lstEntrenadores.DisplayMember = "Nombre";
            lstEntrenadores.ValueMember = "Id";
        }

        private async Task CargarSocios()
        {
            var response = await _httpClient.GetAsync("socios");
            var json = await response.Content.ReadAsStringAsync();
            var socios = JsonConvert.DeserializeObject<List<Socio>>(json);
            lstSocios.DataSource = socios;
            lstSocios.DisplayMember = "Nombre";
            lstSocios.ValueMember = "Id";
        }

        private async void btnAgregarEntrenador_Click(object sender, EventArgs e)
        {
            var entrenador = new
            {
                Nombre = txtEntrenadorNombre.Text,
                Especialidad = txtEntrenadorEspecialidad.Text
            };

            var content = new StringContent(JsonConvert.SerializeObject(entrenador), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("entrenadores", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Entrenador agregado.");
                await CargarEntrenadores();
            }
            else
            {
                MessageBox.Show("Error al agregar entrenador.");
            }
        }

        private async void btnEliminarEntrenador_Click(object sender, EventArgs e)
        {
            if (lstEntrenadores.SelectedItem is Entrenador entrenador)
            {
                var response = await _httpClient.DeleteAsync($"entrenadores/{entrenador.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Entrenador eliminado.");
                    await CargarEntrenadores();
                }
                else
                {
                    MessageBox.Show("Error al eliminar entrenador.");
                }
            }
        }

        private async void btnAgregarSocio_Click(object sender, EventArgs e)
        {
            var socio = new
            {
                Nombre = txtSocioNombre.Text,
                Dni = txtSocioDni.Text
            };

            var content = new StringContent(JsonConvert.SerializeObject(socio), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("socios", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Socio agregado.");
                await CargarSocios();
            }
            else
            {
                MessageBox.Show("Error al agregar socio.");
            }
        }

        private async void btnEliminarSocio_Click(object sender, EventArgs e)
        {
            if (lstSocios.SelectedItem is Socio socio)
            {
                var response = await _httpClient.DeleteAsync($"socios/{socio.Id}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Socio eliminado.");
                    await CargarSocios();
                }
                else
                {
                    MessageBox.Show("Error al eliminar socio.");
                }
            }
        }
    }
}
