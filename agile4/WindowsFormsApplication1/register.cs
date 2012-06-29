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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void goregist(object sender, EventArgs e)
        {
            BLL bll=new BLL();
            string name,pass1;
            label5.Text = "";
            label6.Text = "";
            label7.Text = "";

            if (textBox1.Text == null)
            {
                label5.Text = "用户名不能为空";
                return;
            }
            else
            {
                name=textBox1.Text.ToString();
                pass1="";
               
                if(bll.checkuser(name,pass1)!=2)
                {
                    label5.Text = "用户名已被占用";
                    return;
                }
            }
            if (textBox2.Text == null)
            {
                label6.Text = "密码不能为空";
                return;
            }
            else if (textBox2.Text.ToString().Length < 6)
            {
                label6.Text = "密码长度不能小于6个字符";
                return;
            }
            else if (!(textBox2.Text.ToString().Equals(textBox3.Text.ToString())))
            {
                label7.Text = "两次输入的密码不一致";
                return;
            }
            else
            {
                pass1 = textBox2.Text.ToString();
                bll.insertcustomer(bll.maxid(false)+1, name, pass1);
                MessageBox.Show("注册成功！");
                this.Close();

                login log = (login)this.Owner;
                log.Show();
            }
        }

        private void gofirst(object sender, EventArgs e)
        {
            this.Close();

            login log = (login)this.Owner;
            log.Show();
        }
    }
}
