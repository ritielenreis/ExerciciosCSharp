using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace iKronos.MyUtil
{
    public class connection
    {

        public DataTable Connecta(string SQL)
        {
            string SC;
            //SC = "Data Source=188.121.44.214;Integrated Security = False;database = Kronost;User ID = admin2;Password = 123.abc;Connect Timeout = 15;Encrypt = False;Packet Size = 4096";

            SC = "Data Source=89.154.2.41,62444;database = bdk19.btt;User ID = sa;Password = 123.abc.@";
            
            SqlConnection C = new SqlConnection(SC);
            C.Open();
            SqlCommand command = C.CreateCommand();
            command.CommandText = SQL;
            SqlDataAdapter da = new SqlDataAdapter(command);
            var T = new DataTable();
            da.Fill(T);   //T já tem  os clientes                  
            C.Close();
            return T;
        }


        public int conta_linhas_datatable(DataTable T)
        {
            int contador = 0;
            contador = T.Rows.Count;
            return contador;
        }

    }

         
}