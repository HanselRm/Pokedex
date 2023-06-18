using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Api.Models;

namespace Test_Api
{
    public partial class Form1 : Form
    {
        Pokemon pokemon = new Pokemon();
        public Form1()      {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await BuscarApi();

            if (pokemon.name != null)
            {
                Nombre.Text = pokemon.name;
                Experiencia.Text = pokemon.base_experience.ToString();
                Altura.Text = pokemon.height.ToString();
                Ancho.Text = pokemon.weight.ToString();

                
            }
            else
            {
                MessageBox.Show("Pokemon no encontrado", "Alerta", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
        
        private async Task BuscarApi()
        {
            Api api = new Api();
            pokemon = await api.pruebaAsync(Buscar.Text.ToLower());
        }
    }
}
