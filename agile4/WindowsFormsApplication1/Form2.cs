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

namespace WindowsFormsApplication1
{
    
    public partial class Form2 : Form
    {
        String fileName;
        public int theuserid2;
        public Form2()
        {
            InitializeComponent();
            

            DAL.DataBase db = new DAL.DataBase();
            String sql0 = "select distinct type from file";
            DataSet ds0 = db.GetDataset(sql0);


            ds0.Tables[0].Columns[0].ColumnName = "Type";

            //bindingSource2.DataMember = ds0.Tables[0].ToString();
                      
            comboBox1.ValueMember = "Type";
            comboBox1.DataSource = ds0.Tables[0];

            String type = comboBox1.SelectedValue.ToString();

            db.closeconn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            OpenFileDialog ofd = new OpenFileDialog();                //new一个方法
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //定义打开的默认文件夹位置
            //ofd.Filter = "备份文件(*.bak)|*.bak|所有文件(*.*)|*.*";

            ofd.ShowDialog();          //显示打开文件的窗口
            fileName = ofd.FileName;               //获得选择的文件路径            

            textBox1.Text = fileName;
        }

        private void goback(object sender, EventArgs e)
        {
            this.Close();
            //this.Parent.Show();
            //Form1.ActiveForm.Show();
            
            Form1 fm = (Form1)this.Owner;           
            fm.Show();                       
        }

        private void createnewlabel(object sender, EventArgs e)
        {
            if (textBox2.Visible == false)
            {
                button4.Text = "取消创建";
                textBox2.Visible = true;
            }
            else
            {
                button4.Text = "创建主题";
                textBox2.Visible = false;
            }
        }

        private void upload(object sender, EventArgs e)
        {
            string labelname="";
            string onlyfile="";
            string uristring;
            string path;
            string i = textBox1.Text.ToString();
            if (textBox1.Text.ToString() == "")
            {
                MessageBox.Show("请输入要上传的文件！");
                return;
            }

            if (textBox2.Visible == false)
            {
                labelname = comboBox1.SelectedValue.ToString();
            }
            else if (textBox2.Text.ToString() == "")
            {
                MessageBox.Show("新创建的主题名不能为空哦！");
                return;
            }
            else
                labelname = textBox2.Text;

            
            onlyfile = fileName.Substring(fileName.LastIndexOf("\\") + 1); 
            uristring = "f:\\databaseupdown\\" + labelname + "\\" +onlyfile;
            string p = uristring.Replace("\\", "/");

            path = "f:\\databaseupdown\\" + labelname;

            WebClient myWebClient = new WebClient();
            //设置应用程序的系统凭据  
            myWebClient.Credentials = CredentialCache.DefaultCredentials;
            //要上传的文件穿件文件流  
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite);
            //以二进制方式读取  
            BinaryReader br = new BinaryReader(fs);
            //当前流写入二进制  
            byte[] postArray = br.ReadBytes((int)fs.Length);  



            Stream postStream = myWebClient.OpenWrite(uristring,"PUT");  
            try  
            {  
                if (postStream.CanWrite)  
                {  
                    postStream.Write(postArray, 0, postArray.Length);  
                    postStream.Close();  
                    fs.Dispose();
                    BLL bll = new BLL();
                    int id=bll.maxid(true)+1;
                    DateTime dt=DateTime.Now;
                    //暂且先用new用户的身份插入数值
                    //通过theruserid传值，来用登陆者身份插入数值
                    bll.insertfile(id, onlyfile, labelname, dt, theuserid2, p);
                    MessageBox.Show("上传成功");  
                }  
                else  
                {  
                    postStream.Close();  
                    fs.Dispose();  
                    MessageBox.Show("上传失败");  
                }  
            }  
            catch (Exception ex)  
            {  
  
                postStream.Close();  
                fs.Dispose();  
                MessageBox.Show("上传文件异常" + ex.Message);  
                throw ex;  
            }  
            finally   
            {  
                postStream.Close();  
                fs.Dispose();  
            }  
         
        }
    }
}
