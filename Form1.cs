using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
            //Console.WriteLine("O que gostaria de buscar?");
            //var UserInput = Console.ReadLine(); // recebe o titulo desejado
            var url = "https://www.googleapis.com/youtube/v3/search" + "?key=AIzaSyCPdQiEYNshLaFEJGXNk_sVicC9HLjm9yc&part=snippet&maxResults=25" + "&q=" + UserInput; // cria o link necessario para o pedido get
            string Jsonraw = null;
            var wc = new WebClient(); // cria um webclient para fazer o get da API
            Jsonraw = wc.DownloadString(url); // recebe o JSON
            var data = JsonConvert.DeserializeObject<Rootobject>(Jsonraw); //parse do Json
            /* for (int i = 0; i < data.items.Count(); i++) // imprime os primeiros 25 videos
             {
                 //Console.WriteLine("Titulo: " + data.items[i].snippet.title + "\n");
                 //Console.WriteLine("------------------------------------- \n");
                 //pictureBox1.ImageLocation = data.items[i].snippet.thumbnails.high;

             }*/
            //Console.WriteLine(data.items[1].snippet.thumbnails.high);
            //MessageBox.Show(data.items[1].snippet.thumbnails._default.url);
            string img = data.items[1].snippet.thumbnails.high.url;
            pictureBox1.ImageLocation = img;
            label2.Text = data.items[1].snippet.title;
        }
    }
}
