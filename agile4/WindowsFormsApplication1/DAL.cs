using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace DAL
{
    public class DataBase
    {
         protected MySqlConnection myconn;
        
            public DataBase()
            {
                //
                //TODO: 在此处添加构造函数逻辑
                //

                myconn = new MySqlConnection();

                myconn.ConnectionString = "server=localhost;User Id=root;Persist Security Info=True;database=download;password=rootpass5";
                myconn.Open();
               
            }

            ~DataBase()
            {
                try
                {
                    if (myconn != null)
                        myconn.Close();
                }
                catch { }
            }

            public DataSet GetDataset(string mysql)
            {
                DataSet myds = new DataSet();
                MySqlDataAdapter myda = new MySqlDataAdapter(mysql, myconn);
                //myda.Fill(myds,"student");
                myda.Fill(myds);
                return myds;
            }

            public void execute(string sql)
            {
                MySqlCommand mycmd = new MySqlCommand();
                mycmd.Connection = myconn;
                mycmd.CommandText = sql;
                mycmd.ExecuteNonQuery();
            }

            public void closeconn()
            {
                myconn.Close();
            }

        }
    
}
