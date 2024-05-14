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
    public partial class Form1 : Form
    {
        string kimlik;
        public Form1(string id)
        {
            InitializeComponent();
            kimlik = id;
        }
        OleDbConnection baglanti = new OleDbConnection("provider=microsoft.jet.oledb.4.0;Data source=kutuphane.mdb");

        void listele()
        {
            //açma
            baglanti.Open();
            OleDbDataAdapter data = new OleDbDataAdapter("Select * From kitaplar",baglanti);
            DataTable sorgu = new DataTable();
            data.Fill(sorgu);
            dataGridView1.DataSource = sorgu;
            baglanti.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            string sorgu = "INSERT INTO kitaplar(adi,yazar,tur,raf,sayfa_sayisi,kimlik_no) VALUES ('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"')";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelleme
            string sorgu = "UPDATE kitaplar SET adi= '" + textBox1.Text + "',yazar='" + textBox2.Text + "',tur='" + textBox3.Text + "',raf='" + textBox4.Text + "',sayfa_sayisi='" + textBox5.Text + "' WHERE kimlik_no='" + textBox6.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //silme
            string sorgu = "DELETE FROM kitaplar WHERE adi='" + textBox1.Text + "' AND kimlik_no='" + textBox6.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();

            listele();
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form3=new Form3();
            form3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void dataGridView1_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 kitap = new Form4(kimlik);
            kitap.Show();
            this.Hide();
        }
    }
}
