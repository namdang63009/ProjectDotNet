using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace ProjectDotNet
{
    public partial class Form1 : Form
    {

        DataSet dsKHOA = new DataSet();
        SqlDataAdapter da = null;
        SqlCommand cmd;
        SqlCommandBuilder cb = null;

        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=QLSVien;User ID=sa");//goi no o day cung dc, dang le ra la goi ben kia ma a luoi a goi o day lun
        public Form1()
        {
            InitializeComponent();
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridClick();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            dataGridClick();
        }

        private void dataGridClick()
        {
            int row = dataGridView1.CurrentRow.Index;
            txtTenKhoa.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DataRow newRow = dsKHOA.Tables["KHOA"].NewRow();
            newRow["MAKHOA"] = txtMaKhoa.Text.Trim();
            newRow["TENKHOA"] = txtTenKhoa.Text.Trim();
            newRow["NAMTHANHLAP"] = txtNamThanhLap.Text.Trim();

            dsKHOA.Tables["KHOA"].Rows.Add(newRow);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT * FROM KHOA", ProjectConnection.getConnection());
            cb = new SqlCommandBuilder(da);
            loadDataGrid();

            cmb1.DataSource = dsKHOA.Tables["KHOA"];
            cmb1.DisplayMember = "MAKHOA";
            cmb1.ValueMember = "MAKHOA";

            txtTongKhoa.Text = (dataGridView1.Rows.Count - 1).ToString();
        }

        private void loadDataGrid()
        {
            try
            {
                da.Fill(dsKHOA, "KHOA");
                dataGridView1.DataSource = dsKHOA.Tables["KHOA"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                dataGridView1.DataSource = null;
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dsKHOA.Tables["KHOA"].Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            dsKHOA.AcceptChanges();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //cmd = new SqlCommand("DELETE FROM KHOA", con );
            //con.Open();
            //cmd.ExecuteNonQuery();
            //con.Close();
            //for (int i = 0; i < dataGridView1.Rows.Count; i++) 
            //{
            //    string sql = @"INSERT INTO KHOA (MAKHOA,TENKHOA,NAMTHANHLAP)VALUES('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "')";
            //    cmd = new SqlCommand(sql, con);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //    con.Close();

            //}
            //MessageBox.Show("Lưu dữ liệu thành công");


            try
            {
                da.Update(dsKHOA.Tables["KHOA"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("UPDATE SUCCESS");
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKhoa.Text = "";
            txtNamThanhLap.Text = "";
            txtTenKhoa.Text = "";
            DisplayData();
        }
        private void DisplayData()
        {

            ProjectConnection.getConnection();

            DataTable dt = new DataTable();
            da = new SqlDataAdapter("select * from KHOA", ProjectConnection.getConnection());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmb1.DisplayMember = "MAKHOA";
            cmb1.ValueMember = "TENKHOA";


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
