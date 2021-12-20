using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;
using System.Threading.Tasks;
using System.Linq;

namespace WinFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            baglanti.Open();
            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            string sorgu2 = "select * from  hasta_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr.GetValue(0).ToString();
            }
            baglanti.Close();

        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=hastane; user ID=postgres; password=12345");
        private void Form3_Load(object sender, EventArgs e)
        {
            /*
            baglanti.Open();
            string sorgu = "select * from ilce";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "ilce_adi";
            comboBox1.ValueMember = "ilce_id";
            comboBox1.DataSource = dt;

            baglanti.Close();
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hasta (ad,soyad,tc_no,oda_no,telefon) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox2.Text);
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", (textBox1.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", textBox4.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  hasta_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //silme işlemi
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from hasta where tc_no=@p1", baglanti);

            komut1.Parameters.AddWithValue("@p1", (textBox1.Text));
            komut1.ExecuteNonQuery();

            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  hasta_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //güncelle
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update hasta set ad=@p1,soyad=@p2,oda_no=@p4,telefon=@p5 where tc_no=@p3", baglanti);
            komut1.Parameters.AddWithValue("@p1", textBox2.Text);
            komut1.Parameters.AddWithValue("@p2", textBox3.Text);
            komut1.Parameters.AddWithValue("@p3", (textBox1.Text));
            komut1.Parameters.AddWithValue("@p4", int.Parse(textBox5.Text));
            komut1.Parameters.AddWithValue("@p5", textBox4.Text);
            komut1.ExecuteNonQuery();
            string sorgu = "select * from hasta";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  hasta_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                label9.Text = dr.GetValue(0).ToString();
            }

            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //tc ile hasta ara
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from hasta where tc_no = @p1", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@p1",(textBox1.Text));
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            baglanti.Close();

        }
    }
}
