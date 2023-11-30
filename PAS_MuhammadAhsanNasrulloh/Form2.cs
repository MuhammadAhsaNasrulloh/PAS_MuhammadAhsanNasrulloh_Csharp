    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using MySql.Data.MySqlClient;
    using MySql.Data.Types;
    using static System.Windows.Forms.VisualStyles.VisualStyleElement;

    namespace PAS_MuhammadAhsanNasrulloh
    {
        public partial class Form2 : Form
        {
       
            public Form2()
            {
                InitializeComponent();
            }

            private DataTable table = new DataTable();
    private int selectedRowIndex = -1;

    private void Form2_Load(object sender, EventArgs e)
    {
        // add parameters to the DataTable
        table.Columns.Add("NISN", typeof(string));
        table.Columns.Add("Nama", typeof(string));
        table.Columns.Add("Kelas", typeof(string));
        table.Columns.Add("Jurusan", typeof(string));

        // create DataGridViewTextBoxColumn
        
        DataGridViewCheckBoxColumn cb1 = new DataGridViewCheckBoxColumn();
        cb1.HeaderText = "Hapus";
        

        // add columns to the DataGridView
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] {cb1 });

        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dataGridView1.AllowUserToAddRows = true;
    }

    private void btnView_Click(object sender, EventArgs e)
    {
        if (txtNis.Text == string.Empty || txtNama.Text == string.Empty || cbKelas.Text == string.Empty || cbJurusan.Text == string.Empty)
        {
            MessageBox.Show("Isi dengan Lengkap");
        }
        else
        {
            table.Rows.Add(txtNis.Text, txtNama.Text, cbKelas.Text, cbJurusan.Text);
            dataGridView1.DataSource = table;
            ClearTextBoxes(); // clear textboxes after adding a new row
        }
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            // input datagridview (txtBox into datagrid/table)
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtNis.Text = row.Cells[1].Value.ToString();
            txtNama.Text = row.Cells[2].Value.ToString();
            cbKelas.Text = row.Cells[3].Value.ToString();
            cbJurusan.Text = row.Cells[4].Value.ToString();

            // update selectedRowIndex
            selectedRowIndex = e.RowIndex;
        }
    }

    private void btnDel_Click(object sender, EventArgs e)
    {
        for (int i = dataGridView1.Rows.Count - 1; i >= 0; i--)
        {
            bool delete = false;
            if (dataGridView1.Rows[i].Cells[4].Value != null)
            {
                delete = (bool)dataGridView1.Rows[i].Cells[0].Value;
            }

            if (delete)
            {
                DataGridViewRow rowToRemove = dataGridView1.Rows[i];
                dataGridView1.Rows.Remove(rowToRemove);
            }
        }
    }

    private void ClearTextBoxes()
    {
        txtNis.Text = string.Empty;
        txtNama.Text = string.Empty;
        cbKelas.Text = string.Empty;
        cbJurusan.Text = string.Empty;
    }

        }
    }
