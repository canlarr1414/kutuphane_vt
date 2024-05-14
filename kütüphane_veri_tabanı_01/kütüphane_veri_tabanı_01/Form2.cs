using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace kütüphane_veri_tabanı_01
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;Data source=kutuphane.mdb");


      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool giris_basarilimi = false;
            string sorgu = "Select * FROM kullanıcı";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();

            OleDbDataReader okuma = komut.ExecuteReader();

            while (okuma.Read())
            {
                if (okuma.GetValue(1).ToString() == textBox1.Text && okuma.GetValue(4).ToString() == textBox2.Text)
                {
                    giris_basarilimi = true;
                    Form1 form1 = new Form1(okuma.GetValue(0).ToString());
                    this.Hide();
                    form1.Show();
                }
            }

            if (giris_basarilimi == false)
            {
                MessageBox.Show("Kullanıcı adı veya parola yanlış");
            }
            baglanti.Close();
        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Show();
            this.Hide();
        }
    }
}
