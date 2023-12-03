using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAS_MuhammadAhsanNasrulloh
{
    public partial class Form3 : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;username=root;password=;database=pas_muhammadahsan");
        void command(String query)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void showData()
        {
            try
            {
                conn.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("select * from tb_data", conn);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        void clear()
        {
            txtNISN.Text = string.Empty;
            txtNama.Text = string.Empty;
            cbKelas.Text = string.Empty;
            cbJurusan.Text = string.Empty;
            showData();
        }
        public Form3()
        {
            InitializeComponent();
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtNISN.Text == string.Empty || txtNama.Text == string.Empty || cbKelas.Text == string.Empty || cbJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                command("insert into tb_data(NIS, Nama, Kelas, Jurusan) values ('" + txtNISN.Text + "', '" + txtNama.Text + "', '" + cbKelas.Text + "', '" + cbJurusan.Text + "')");
                clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNISN.Text == string.Empty || txtNama.Text == string.Empty || cbKelas.Text == string.Empty || cbJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                command("update tb_data set NIS  = '" + txtNISN.Text + "', Nama = '" + txtNama.Text + "', Kelas = '" + cbKelas.Text + "', Jurusan = '" + cbJurusan.Text + "' where NIS = '" + txtNISN.Text + "'");
                clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtNISN.Text == string.Empty || txtNama.Text == string.Empty || cbKelas.Text == string.Empty || cbJurusan.Text == string.Empty)
            {
                MessageBox.Show("semua kolom harus di isi!");
            }
            else
            {
                command("delete from tb_data where NIS = '" + txtNISN.Text + "'");
                clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private int selectedRowIndex;
        DataTable table = new DataTable();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dr = this.dataGridView1.Rows[e.RowIndex];

            txtNISN.Text = dr.Cells[0].Value.ToString();
            txtNama.Text = dr.Cells[1].Value.ToString();
            cbKelas.Text = dr.Cells[2].Value.ToString();
            cbJurusan.Text = dr.Cells[3].Value.ToString();

            selectedRowIndex = e.RowIndex;
        }
    }
}
    