using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
     public class TaskDAL
    {
        public bool AddTask(Task task)
        {
            bool operationStatus = false;
            string str = ConfigurationManager.ConnectionStrings["TaskConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("[dbo].sp_InsertTask", cn);

            try
            {

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_Title", task.ti);
                cmd.Parameters.AddWithValue("@p_Description", dept.Loc);
                cmd.Parameters.AddWithValue("@p_Status", dept.MgrName);
                cmd.Parameters.AddWithValue("@p_Duedate", dept.MgrName);
                cn.Open();
                cmd.ExecuteNonQuery();
                operationStatus = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                cn.Close();
                cn.Dispose();

            }
            return operationStatus;

        }

    }
}
