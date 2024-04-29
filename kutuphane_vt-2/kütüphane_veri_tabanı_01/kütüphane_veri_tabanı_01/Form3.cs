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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;Data source=kutuphane.mdb");
        void listele()
        {
            //açmak
            baglanti.Open();
            OleDbDataAdapter data = new OleDbDataAdapter("Select * From ogrenciler", baglanti);
            DataTable sorgu = new DataTable();
            data.Fill(sorgu);
            dataGridView1.DataSource = sorgu;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //silmek
            string sorgu = "DELETE FROM ogrenciler  WHERE kitap_isim='" + textBox1.Text + "' AND barkod='" + textBox4.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //eklemek
            string sorgu = "INSERT INTO ogrenciler(kitap_isim,kitap_syf,kitap_tür,barkod) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //güncellemek
            string sorgu = "UPDATE ogrenciler SET kitap_isim= '" + textBox1.Text + "',kitap_syf='" + textBox2.Text + "',kitap_tür='" + textBox3.Text + "',barkod='" + textBox4.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
