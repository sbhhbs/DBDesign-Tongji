using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;

namespace crazy
{
    class ManagermentAction
    {
        public SqlConnection con;
        public ManagermentAction()
        {
            con = null;
        }
        public ManagermentAction(string str)
        {
            con = new SqlConnection(str);
        }

        public void insert_managerment_action(int manager_id,int card_id,
                    int action,DateTime action_time,string description,float money)
        {
            string mystr = "for_insert_managerment_action";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@manager_id", SqlDbType.Int);
            sp.Value = manager_id;
            sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;
            sp = mycmd.Parameters.Add("@action", SqlDbType.Int);
            sp.Value = action;
            sp = mycmd.Parameters.Add("@action_time", SqlDbType.DateTime);
            sp.Value = action_time;
            sp = mycmd.Parameters.Add("@description", SqlDbType.VarChar,120);
            sp.Value = description;
            sp = mycmd.Parameters.Add("@money", SqlDbType.Float);
            sp.Value = money;
            mycmd.ExecuteNonQuery();
        }
        public SqlDataReader manageroperation(int id)
        {
            string str = SQLSERVER.sqlstring;
            Manager manager = new Manager(str);
            //if (!manager.check_manager_isexist(id))
            //{
            //    return false;
            //}
            string mystr = "for_get_managerment_record";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@manager_id", SqlDbType.Int);
            sp.Value = id;
            SqlDataReader myreader = mycmd.ExecuteReader();
            return myreader;//以下待定
            //myreader.Close();
            //con.Close();
            //return true;
        }
    }
}
