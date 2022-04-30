using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using static Youtube.Class1;

namespace Youtube
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var UserInput = textBox1.Text;
            var url = "https://www.googleapis.com/youtube/v3/search" + "?key=AIzaSyCPdQiEYNshLaFEJGXNk_sVicC9HLjm9yc&part=snippet&maxResults=25" + "&q=" + UserInput; // cria o link necessario para o pedido get
            string Jsonraw = null;
            var wc = new WebClient(); // cria um webclient para fazer o get da API
            Jsonraw = wc.DownloadString(url); // recebe o JSON
            var data = JsonConvert.DeserializeObject<Rootobject>(Jsonraw); //parse do Json
            PictureBox[] Show = new PictureBox[100]; // cria array de thumbnails
            PictureBox Thumb = Show[25];
            Label[] Title = new Label[100]; // cria array do nome de cada video
            Label titulo = Title[25];
            CheckBox[] Save = new CheckBox[100];
            CheckBox marked = Save[25];
            for (int i = 0; i < 25; i++) // loop de impressao das thumbnails e titulos
            {
                string nome = data.items[i].snippet.title;
                string img = data.items[i].snippet.thumbnails.medium.url;
                Show[i] = new PictureBox(); // declara a picture box evitando erro
                Title[i] = new Label();
                Save[i] = new CheckBox();
                this.Controls.Add(Show[i]);
                this.Controls.Add(Title[i]);
                this.Controls.Add(Save[i]);

                Title[i].Location = new Point(12, i * 375 + 35);
                Show[i].Location = new Point(12, i * 375 + 50); // garante impressao linear
                Save[i].Location = new Point(370, i * 375 + 50);
                Save[i].Size = new Size(50, 20);
                Show[i].Size = new Size(350, 250); // tamanho fixo, as imagens ainda flutuam de tamanho por conta do retorna da API (REVER)
                Title[i].Size = new Size(350, 250);
                Show[i].ImageLocation = img;
                Title[i].Text = nome;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}