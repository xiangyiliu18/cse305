using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Final
{
    class Class1
    {
        public string file;
        public DataSet set = new DataSet();
        public Class1(string filename)
        {
            file = filename;
        }
        public void nonQuery(string sql)
        {
            string connetionString = null;
            MySqlConnection myconn1;
            connetionString = "server=localhost;database=ecommerce;uid=root;pwd=691029;";
            myconn1 = new MySqlConnection(connetionString);
            myconn1.Open();
            MySqlCommand cmd = new MySqlCommand(sql, myconn1);
            //Execute command
            cmd.ExecuteNonQuery();
            myconn1.Close();
        }
        public void query(string sql)
        {
            string connetionString = null;
            MySqlConnection myconn;
            connetionString = "server=localhost;database=ecommerce;uid=root;pwd=691029;";
            myconn = new MySqlConnection(connetionString);
            myconn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, myconn);
            MySqlDataAdapter myadap = new MySqlDataAdapter(sql, myconn);
            MySqlCommandBuilder mybuid = new MySqlCommandBuilder(myadap);
            myadap.Fill(set);
            myconn.Close();

        }
    }

}
