using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int theuserid;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //login loginin =(login) this.Owner;
            //loginin.Hide();
            // TODO: 这行代码将数据加载到表“downloadDataSet3.customer”中。您可以根据需要移动或删除它。
            this.customerTableAdapter.Fill(this.downloadDataSet3.customer);
            // TODO: 这行代码将数据加载到表“downloadDataSet2.file”中。您可以根据需要移动或删除它。
            this.fileTableAdapter2.Fill(this.downloadDataSet2.file);
            // TODO: 这行代码将数据加载到表“downloadDataSet1.file”中。您可以根据需要移动或删除它。
            this.fileTableAdapter1.Fill(this.downloadDataSet1.file);
            // TODO: 这行代码将数据加载到表“downloadDataSet.file”中。您可以根据需要移动或删除它。
            this.fileTableAdapter.Fill(this.downloadDataSet.file);



            BLL bll = new BLL();

            DataSet ds = bll.basic();
            DataTable dt = ds.Tables[0];
            int c = dt.Columns.Count;
            String test = dt.Rows[0][0].ToString();
            dt.TableName="file";
            //测试修改列名
            dt.Columns[0].ColumnName = "资料名";
            dt.Columns[1].ColumnName = "主题";
            dt.Columns[2].ColumnName = "上传者";
            dt.Columns[3].ColumnName = "时间";
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "file";
            dataGridView1.AutoGenerateColumns = true;
            /*
            int count = dataGridView1.ColumnCount;
            
            dataGridView1.Columns[0].DataPropertyName = "资料名";
            dataGridView1.Columns[1].DataPropertyName = "主题";
            dataGridView1.Columns[2].DataPropertyName = "上传者";
            dataGridView1.Columns[3].DataPropertyName = "时间";
            
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {                
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //测试修改列名
                //dataGridView1.Columns[i].Name = "测试";
            } */


            DateTime tt=dateTimePicker1.Value;

            
            DataSet dstime = bll.getbasicontime(tt);
            dstime.Tables[0].TableName="time";

            dstime.Tables[0].Columns[0].ColumnName = "资料名";
            dstime.Tables[0].Columns[1].ColumnName = "主题";
            dstime.Tables[0].Columns[2].ColumnName = "上传者";
            dstime.Tables[0].Columns[3].ColumnName = "时间";

            dataGridView4.DataSource = dstime;
            dataGridView4.DataMember = "time";
            dataGridView4.AutoGenerateColumns = true;


            
            //dataGridView1.DataSource = bindingSource3;
            //dataGridView1.

            DataTable dt1 = bll.showtype();
            dt1.Columns[0].ColumnName = "Type";

            //bindingSource2.DataMember = ds0.Tables[0].ToString();

            //int all = bindingSource2.Count;
            bindingSource2.DataSource = dt1;
            comboBox1.ValueMember = "Type";
            comboBox1.DataSource = bindingSource2;
            String type = comboBox1.SelectedValue.ToString();

            DataTable dt2 = bll.showuper();

            dt2.Columns[0].ColumnName = "uper";

            comboBox2.ValueMember = "uper";
            comboBox2.DataSource = dt2;


            panel1.Visible = true;

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;


            BLL bll = new BLL();

            DataSet ds = bll.basic();
            DataTable dt = ds.Tables[0];
            int c = dt.Columns.Count;
            String test = dt.Rows[0][0].ToString();
            dt.TableName = "file";

            dt.Columns[0].ColumnName = "资料名";
            dt.Columns[1].ColumnName = "主题";
            dt.Columns[2].ColumnName = "上传者";
            dt.Columns[3].ColumnName = "时间";

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "file";
            dataGridView1.AutoGenerateColumns = true;
            /*
            int count = dataGridView1.ColumnCount;
            
            dataGridView1.Columns[0].DataPropertyName = "资料名";
            dataGridView1.Columns[1].DataPropertyName = "主题";
            dataGridView1.Columns[2].DataPropertyName = "上传者";
            dataGridView1.Columns[3].DataPropertyName = "时间";
             
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //测试修改列名
                //dataGridView1.Columns[i].Name = "测试";
            }*/
        }

        

        private void download_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.ShowDialog(this);
        }

        private void upload_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.theuserid2 = theuserid;
            //form.Parent = this;
            //form.Owner = this;
            //form.MdiParent = this;
            form.ShowDialog(this);
            
        }

        private void selecttype(object sender, EventArgs e)
        {
            BLL bll = new BLL();
            
            String type = comboBox1.SelectedValue.ToString();

            DataTable dt = bll.getbasicfromtype(type);
            
            dt.Columns[0].ColumnName = "资料名";
            dt.Columns[1].ColumnName = "主题";
            dt.Columns[2].ColumnName = "上传者";
            dt.Columns[3].ColumnName = "时间";
                        
            dataGridView2.DataSource = dt;
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.fileTableAdapter2.FillBy(this.downloadDataSet2.file);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillByToolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.fileTableAdapter1.FillBy(this.downloadDataSet1.file);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void showtypeitem(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = true;
            panel4.Visible = true;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;

            BLL bll=new BLL();

            DataTable dt=bll.showtype();
            dt.Columns[0].ColumnName = "Type";
            
            //bindingSource2.DataMember = ds0.Tables[0].ToString();
            
            //int all = bindingSource2.Count;
            bindingSource2.DataSource = dt;
            comboBox1.ValueMember = "Type";
            comboBox1.DataSource = bindingSource2;
            
            String type = comboBox1.SelectedValue.ToString();

            DataTable dt2 = bll.getbasicfromtype(type);

            dt2.Columns[0].ColumnName = "资料名";
            dt2.Columns[1].ColumnName = "主题";
            dt2.Columns[2].ColumnName = "上传者";
            dt2.Columns[3].ColumnName = "时间";

            dataGridView2.DataSource = dt2;
        }

        private void selectuper(object sender, EventArgs e)
        {
            BLL bll = new BLL();

            String uper = comboBox2.SelectedValue.ToString();

            DataSet ds = bll.getbasicformuper(uper);
            ds.Tables[0].TableName = "uper";

            ds.Tables[0].Columns[0].ColumnName = "资料名";
            ds.Tables[0].Columns[1].ColumnName = "主题";
            ds.Tables[0].Columns[2].ColumnName = "上传者";
            ds.Tables[0].Columns[3].ColumnName = "时间";

            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "uper";
            
        }

        private void showuperitem(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
            panel7.Visible = true;
            panel8.Visible = false;
            BLL bll = new BLL();

            DataTable dt = bll.showuper();

            dt.Columns[0].ColumnName = "uper";

            comboBox2.ValueMember = "uper";
            comboBox2.DataSource = dt;
            dataGridView4.AutoGenerateColumns = true;
        }

        private void selecttime(object sender, EventArgs e)
        {
            
            DateTime tt = dateTimePicker1.Value;

            BLL bll = new BLL();

            DataSet dstime = bll.getbasicontime(tt) ;
            dstime.Tables[0].TableName = "time";

            dstime.Tables[0].Columns[0].ColumnName = "资料名";
            dstime.Tables[0].Columns[1].ColumnName = "主题";
            dstime.Tables[0].Columns[2].ColumnName = "上传者";
            dstime.Tables[0].Columns[3].ColumnName = "时间";

            dataGridView4.DataSource = dstime;
            dataGridView4.DataMember = "time";
            dataGridView4.AutoGenerateColumns = true;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {               
                dataGridView4.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

        }

        private void showtimeitem(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = true;
            panel7.Visible = false;
            panel8.Visible = true;
        }

        private void gofirst(object sender, EventArgs e)
        {
            this.Close();

            login log = (login)this.Owner;
            log.Show();
            //log.Close();
        }
    }
}
