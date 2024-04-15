using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CRUD.Models;
using System.Data;

namespace CRUD.DAL
{
    public class Dal
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);

        //emp data

        public List<Emp_Model> Getemp()

        {
            List<Emp_Model> emp_Models = new List<Emp_Model>();
            SqlCommand cmd = new SqlCommand("select * from emp", con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                emp_Models.Add(new Emp_Model()
                 {
                       Empid =Convert.ToInt32(dr[0]),
                       EmpName = Convert.ToString(dr[1]),
                       EmpDept = Convert.ToString(dr[2]),

                });
            }
            return emp_Models;

        }

        public bool Add (Emp_Model em)
        {
            int i;
            string qry = "insert into Emp values(@id,@nm,@dept)";
            SqlCommand cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id",Convert.ToInt32 (em.Empid));
            cmd.Parameters.AddWithValue("@nm", Convert.ToString(em.EmpName));
            cmd.Parameters.AddWithValue("@dept", Convert.ToString(em.EmpDept));
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }
            
        }

        //update
        public bool Emp_Update(Emp_Model rg)
        {
            int i;
            string str = "update emp set empname=@nm,empdept=@dept where empid=@id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", rg.Empid);
            cmd.Parameters.AddWithValue("@nm", rg.EmpName);
            cmd.Parameters.AddWithValue("@dept", rg.EmpDept);

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        //delete
        public bool Delete(int id)
        {
            int i;
            string str = "delete emp where empid=@id";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            

            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;

            }
            else
            {
                return false;
            }

        }

    }
}