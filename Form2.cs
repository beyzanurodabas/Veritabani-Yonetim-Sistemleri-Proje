using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Linq;
using System.Threading.Tasks;
using Npgsql;


namespace WinFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
            baglanti.Open();
            string sorgu = "select * from doktor order by doktor_id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  doktor_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader drs = komut2.ExecuteReader();
            while (drs.Read())
            {
                label11.Text = drs.GetValue(0).ToString();
            }
            baglanti.Close();
            
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=hastane; user ID=postgres; password=12345");
        private void Form2_Load(object sender, EventArgs e)
        {
            // comboBox1.Items.Add("göz");
            baglanti.Open();
            string sorgu = "select * from brans";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "brans_adi";
            comboBox1.ValueMember = "brans_adi";
            comboBox1.DataSource = dt;

            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //id ile doktor ara
            
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("select * from doktor where doktor_id = @p1", baglanti); //sorgu yazıldı.da nesnesi  iki parametre alacak. 1.si sorgunun ismi 2. bagşantı
            da.SelectCommand.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            DataSet ds = new DataSet(); //veri kümesi oluştu
            da.Fill(ds); //datadaptertla veri kümesi dolacak
            dataGridView2.DataSource = ds.Tables[0]; //data kaynagı olarak ds'yi gönderecek ve bu hafızadaki ilk tabloyu yazdırdı
            baglanti.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //guncelle
            
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("update doktor set ad=@p2,soyad=@p3,brans_adi=@p4,telefon=@p5,hastane_no=@p6 where doktor_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", textBox3.Text);
            komut1.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            komut1.Parameters.AddWithValue("@p5", textBox4.Text);
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox5.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by doktor_id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  doktor_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader drs = komut2.ExecuteReader();
            while (drs.Read())
            {
                label11.Text = drs.GetValue(0).ToString();
            }
            baglanti.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //silme
            
             baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("delete from doktor where doktor_id=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by doktor_id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  doktor_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader drs = komut2.ExecuteReader();
            while (drs.Read())
            {
                label11.Text = drs.GetValue(0).ToString();
            }
            baglanti.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ekleme
            
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into doktor (doktor_id,ad,soyad,brans_adi,telefon,hastane_no) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
           
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox1.Text));
            komut1.Parameters.AddWithValue("@p2", textBox2.Text);
            komut1.Parameters.AddWithValue("@p3", textBox3.Text);
            komut1.Parameters.AddWithValue("@p4", comboBox1.SelectedValue.ToString());
            komut1.Parameters.AddWithValue("@p5", textBox4.Text);
            komut1.Parameters.AddWithValue("@p6", int.Parse(textBox5.Text));

            komut1.ExecuteNonQuery();
            string sorgu = "select * from doktor order by doktor_id asc";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            string sorgu2 = "select * from  doktor_sayisi()";
            NpgsqlCommand komut2 = new NpgsqlCommand(sorgu2, baglanti);
            NpgsqlDataReader drs = komut2.ExecuteReader();
            while (drs.Read())
            {
                label11.Text = drs.GetValue(0).ToString();
            }

            baglanti.Close();

            
        }
    }
}
