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
    public partial class Form4 : Form
    {
        string kimlik;
        public Form4(string id)
        {
            InitializeComponent();
            kimlik = id;
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;Data source=kutuphane.mdb");
        OleDbDataAdapter data;
        void listele()
        {
            baglan.Open();
            data = new OleDbDataAdapter("SELECT *From kullanıcı",baglan);
            DataTable tablo=new DataTable();
            data.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglan.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //güncelleme
            baglan.Open();
            /*
            string sorgula=("Select * from kullanıcı");
            OleDbCommand komut = new OleDbCommand(sorgula, baglan);
            
            OleDbDataReader okuma = komut.ExecuteReader();
            okuma.Read();
            
            komut.ExecuteNonQuery();
         */
           string sorgu = "UPDATE kullanıcı SET parola='" + textBox3.Text + "' WHERE Kimlik="+kimlik;
           OleDbCommand komut2 = new OleDbCommand(sorgu, baglan);
           komut2.ExecuteNonQuery();
            baglan.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1(kimlik);
            frm.Show();
            this.Hide();
        }
    }
}
