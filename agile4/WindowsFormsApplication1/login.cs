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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void gologin(object sender, EventArgs e)
        {
            label3.Text = "";
            label4.Text = "";
            label5.Text = "";

            if (textBox1.Text == null)
            {
                label3.Text = "用户名不能为空";
                return;
            }
            if (textBox2.Text == null)
            {
                label4.Text = "密码不能为空";
                return;
            }

            string name = textBox1.Text.ToString();
            string password = textBox2.Text.ToString();

            BLL bll=new BLL();
            int number=bll.checkuser(name, password);
            switch (number)
            {
                case 0: label5.Text = "输入有误，请重输"; return; 
                
                case 2: label3.Text = "用户名不存在"; return;
                default:
                        this.Hide();
                        Form1 form = new Form1();
                        form.theuserid = number;
                        form.ShowDialog(this); break;
            }


        }

        private void goregist(object sender, EventArgs e)
        {
            this.Hide();
            register re = new register();
            re.ShowDialog(this);
             
        }
    }
}
