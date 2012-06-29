using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        String type, uper, title;
        public Form3()
        {
            InitializeComponent();

           
            BLL bll = new BLL();

            DataTable dt1 = bll.showtype();
            
            dt1.Columns[0].ColumnName = "type";
            DataRow dr1 = dt1.NewRow();
            dr1["type"] = "未知";
            dt1.Rows.Add(dr1);

            comboBox1.DataSource = dt1;
            comboBox1.DisplayMember = "type";
            comboBox1.ValueMember = "type";
            comboBox1.SelectedIndex = dt1.Rows.Count-1;
            //comboBox1.Items.Add("未知");
            //comboBox1.Items.Insert(0, "unkown");

            type = comboBox1.SelectedValue.ToString();
            
            
            DataTable dt2 = bll.showuper();
            dt2.Columns[0].ColumnName = "uper";
            DataRow dr2 = dt2.NewRow();
            dr2["uper"] = "未知";
            dt2.Rows.Add(dr2);

            comboBox2.DataSource = dt2;
            comboBox2.DisplayMember = "uper";
            comboBox2.ValueMember = "uper";
            comboBox2.SelectedIndex = dt2.Rows.Count - 1;

            uper = comboBox2.SelectedValue.ToString();

            DataTable dt3 = bll.showtitle();
            dt3.Columns[0].ColumnName = "title";
           
            comboBox3.DataSource = dt3;
            comboBox3.DisplayMember = "title";
            comboBox3.ValueMember   = "title";

            title = comboBox3.SelectedValue.ToString();
            label4.Text = "(您要下载的是\n   主题为  ：" + comboBox1.SelectedValue.ToString() +
                        "\n   上传者为：" + comboBox2.SelectedValue.ToString() +
                        "\n   文章名为：" + comboBox3.SelectedValue.ToString() + "\n的资料!)";
            
                       
        }

        
        private void labeltextchange()
        {
            label4.Text = "(您要下载的是\n   主题为  ：" + type +
                        "\n   上传者为：" + uper +
                        "\n   文章名为：" + title + "\n的资料!)";
            
        }

        private void download(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();

            BLL bll=new BLL();
            //string URL = "f:\\databaseupdown\\" + type + "\\" + title;
            string p = bll.getpath(title, type, uper);

            if (p.Equals(""))
            {
                MessageBox.Show("数据库中未提供路径！");
                return;
            }


            string URL = p.Replace("/","\\");
            string path = save.FileName;
            string onlyfilename = path.Substring(path.LastIndexOf("\\") + 1);

            WebClient client = new WebClient(); 

            try
            {
                WebRequest myRe = WebRequest.Create(URL);

            }
            catch (Exception ex)
            {
                MessageBox.Show("下载文件异常" + ex.Message);
            }
            try
            {
                client.DownloadFile(URL, onlyfilename);
                FileStream fs = new FileStream(onlyfilename, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int length = (int)fs.Length;
                byte[] mybyte = br.ReadBytes(length);
                Thread.Sleep(2000);
                fs.Close();
                //进程占用出现在这里，访问不了文件
                //FileStream fc = File.Create(path);
                //fc.Close();
                FileStream fstm = new FileStream(path, FileMode.Create, FileAccess.Write);

                fstm.Write(mybyte, 0, length);
                fstm.Close();
                MessageBox.Show("下载文件成功！");
            }
            catch (Exception ex)
            {

                MessageBox.Show("下载文件异常" + ex.Message);
            }  
        }

        private void goback(object sender, EventArgs e)
        {
            this.Close();

            Form1 fm = (Form1)this.Owner;
            fm.Show();
        }

        private void combo1change(object sender, EventArgs e)
        {
            type = comboBox1.SelectedValue.ToString();
            if (type.Equals("未知"))
            {
                labeltextchange();
            }
            else
            {
                BLL bll = new BLL();
                DataTable dt = bll.uperrestrictedbytype(type);
                dt.Columns[0].ColumnName = "uper";
                DataRow dr = dt.NewRow();
                dr["uper"] = "未知";
                dt.Rows.Add(dr);

                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "uper";
                comboBox2.ValueMember = "uper";
                comboBox2.SelectedIndex = dt.Rows.Count - 1;

                DataTable dt2 = bll.titlerestrictedbytype(type);
                dt2.Columns[0].ColumnName = "title";
                comboBox3.DataSource = dt2;
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "title";
            }
        }

        private void combo2change(object sender, EventArgs e)
        {
            uper = comboBox2.SelectedValue.ToString();
            if (uper.Equals("未知"))
            {
                labeltextchange();
            }
            else
            {
                BLL bll = new BLL();
                DataTable dt = bll.titlerestrictedbytypeuper(type,uper);
                dt.Columns[0].ColumnName = "title";
                comboBox3.DataSource = dt;
                comboBox3.DisplayMember = "title";
                comboBox3.ValueMember = "title";
            }
        }

        private void combo3change(object sender, EventArgs e)
        {
            title = comboBox3.SelectedValue.ToString();
            labeltextchange();
        }
    }
}
