using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace WindowsFormsApplication1
{
    class BLL
    {
        public BLL()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public DataSet basic()
        {
            DAL.DataBase db = new DAL.DataBase();

            string sql = "select title,type,name,time from file,customer where userid=customer.id";
            DataSet ds = db.GetDataset(sql);
            db.closeconn();
            return ds;
        }

        public DataSet getbasicontime(DateTime tt)
        {
            DAL.DataBase db = new DAL.DataBase();

            DateTime t = tt.Date;
            DateTime t2 = t.AddDays(1);

            string sqltime = "select title,type,name,time from file,customer where userid=customer.id and time>='" + t + "' and time<='" + t2 + "'";

            DataSet ds = db.GetDataset(sqltime);
            db.closeconn();
            return ds;
        }

        public DataTable getbasicfromtype(string type)
        {
            DAL.DataBase db = new DAL.DataBase();

            String sql = "select title,type,name,time from file,customer where userid=customer.id and type='" + type + "'";

            DataSet ds = db.GetDataset(sql);
            DataTable dt = ds.Tables[0];
            db.closeconn();
            return dt;
        }

        public DataTable showtype()
        {
            DAL.DataBase db = new DAL.DataBase();
            String sql0 = "select distinct type from file";
            DataSet ds0 = db.GetDataset(sql0);

            DataTable dt = ds0.Tables[0];

            db.closeconn();
            return dt;
        }

        public DataSet getbasicformuper(string uper)
        {
            DAL.DataBase db = new DAL.DataBase();

            String sql = "select title,type,name,time from file,customer where userid=customer.id and name='" + uper + "'";

            DataSet ds = db.GetDataset(sql);
            DataTable dt = ds.Tables[0];

            db.closeconn();
            return ds;
        }

        public DataTable showuper()
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "select distinct name from customer,file where userid=customer.id";
            DataSet ds = db.GetDataset(sql);
            DataTable dt = ds.Tables[0];
            db.closeconn();
            return dt;
        }

        public DataTable showtitle()
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "select distinct title from file";

            DataTable dt = db.GetDataset(sql).Tables[0];
            db.closeconn();

            return dt;
        }

        public DataTable uperrestrictedbytype(string type)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "select distinct name from file,customer where userid=customer.id and type='" + type + "'";

            DataTable dt = db.GetDataset(sql).Tables[0];
            db.closeconn();

            return dt;
        }

        public DataTable titlerestrictedbytype(string type)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "select distinct title from file where type='" + type + "'";

            DataTable dt = db.GetDataset(sql).Tables[0];
            db.closeconn();

            return dt;
        }

        public DataTable titlerestrictedbytypeuper(string type, string uper)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "select distinct title from file,customer where userid=customer.id and type='" + type + "' and name='" + uper + "'";

            DataTable dt = db.GetDataset(sql).Tables[0];
            db.closeconn();

            return dt;
        }

        public int maxid(bool choose)
        {
            DAL.DataBase db = new DAL.DataBase();
            DataTable dt;
            string sql1 = "select max(id) from customer";

            string sql2 = "select max(id) from file";

            if (choose)
            {
                dt = db.GetDataset(sql2).Tables[0];
            }
            else
            {
                dt = db.GetDataset(sql1).Tables[0];
            }

            db.closeconn();

            return (int)dt.Rows[0][0];
        }


        public void insertfile(int id, string title, string type, DateTime dt, int userid, string path)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "insert into file(id,title,type,time,userid,path) values(" + id + ",'" + title + "','" + type + "','" + dt + "'," + userid + ",'" + path + "')";
            db.execute(sql);
            db.closeconn();
        }

        public void insertcustomer(int id, string name, string pass)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql = "insert into customer(id,name,password) values(" + id + ",'" + name + "','" + pass + "')";
            db.execute(sql);
            db.closeconn();
        }

        public string getpath(string title, string type, string uper)
        {
            DAL.DataBase db = new DAL.DataBase();
            string sql;
            DataTable dt;

            if (uper == "未知")
            {
                if (type == "未知")
                {
                    sql = "select path from file where title='" + title + "'";

                }
                else
                {
                    sql = "select path from file where title='" + title + "' and type='" + type + "'";
                }
            }
            else
            {
                if (type == "未知")
                {
                    sql = "select path from file where title='" + title + "' and userid=(select id from customer where name='" + uper + "')";;
                }
                else
                    sql = "select path from file where title='" + title + "' and type='" + type + "' and userid=(select id from customer where name='" + uper + "')";
            }

            dt = db.GetDataset(sql).Tables[0];

            db.closeconn();
            if (dt.Rows[0][0] != null)
                return (string)dt.Rows[0][0];
            else
                return "";
        }

        public int checkuser(string name, string pass)
        {
            DAL.DataBase db = new DAL.DataBase();

            string sql = "select id from customer where name='" + name + "' and password='" + pass + "'";
            DataTable dt = db.GetDataset(sql).Tables[0];
            string sqln = "select id from customer where name='" + name + "'";
            DataTable dtn = db.GetDataset(sqln).Tables[0];

            if (dtn.Rows.Count == 0)
                return 2;
            else if (dt.Rows.Count!=0)
                return (int)dt.Rows[0][0];
            else
                return 0;
        }

    }
    
}
