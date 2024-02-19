using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLibrary
{
    class TaskDAL
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
                cmd.Parameters.AddWithValue("@p_Title",task.Title);
                cmd.Parameters.AddWithValue("@p_Description", task.Description);
                cmd.Parameters.AddWithValue("@p_Status", task.Status);
                cmd.Parameters.AddWithValue("@p_Duedate", task.Duedate);
                cmd.Parameters.AddWithValue("@p_UserId", task.UserId);
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
