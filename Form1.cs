using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //System.Threading.Thread.Sleep(5000); //No se utiliza en Async porque no es Asíncrono
            Task.Run(async () => {
                string dato = await PruebaAsync();
                MessageBox.Show(dato);
            }).GetAwaiter().GetResult();
            MessageBox.Show("Mensaje");
        }

        private async Task<string> PruebaAsync()
        {
            pictureBox1.Visible = true;
            await Task.Delay(5000); //Simulando la espera de una respuesta
            pictureBox1.Visible = false;
            return "Fin";
        }
    }
}
