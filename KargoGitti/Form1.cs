using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace KargoGitti
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "qb8xv0dnM3HGtFqQIJSgEWKA01eMuo1Gv7OVBv6j",
            BasePath = "https://clear-safeguard-329609-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
       

            if (client != null)
            {
                MessageBox.Show("Firebase baglantısı kuruldu");
            }

        }

        private async void kayitBtn_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                KullaniciAdi = textBox3.Text,
                Sifre = maskedTextBox1.Text,

            };
            SetResponse response = await client.SetTaskAsync("Information/" + textBox3.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Kayıt olundu " + result.KullaniciAdi);
        }

        private void GirisBtn_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = client.Get("Information/" + textBox3.Text);

            Data obj = response.ResultAs<Data>();
            var user = new Data
            {
                KullaniciAdi = textBox3.Text,
                Sifre = maskedTextBox1.Text,

            };

            if (user.KullaniciAdi != obj.KullaniciAdi)
            {
                MessageBox.Show("Kullanici bulunamadı");
            }
            else if (user.Sifre != obj.Sifre)
            {
                MessageBox.Show("Kullanici adi ve sifre uyusmadi");
            }
            else
            {
                MessageBox.Show("Giris yapildi");
                Form2 form2 = new Form2();
                form2.Show();  // form2 göster diyoruz

                this.Hide();
            }

        }
    }
}
