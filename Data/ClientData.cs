using Npgsql;
using System.Data;
using System.Data.SqlClient;
using Tourism.Client.Models;

namespace Tourism.Client.Data
{
    public class ClientData: IClientData
    {
        public List<Ent_Client> Get_listClient()
        {
            List<Ent_Client> list = null;
            //string sqlquery = "\"SP_LIST_CLIENT\"";
            string sqlquery = "SELECT \"CLIENT_ID\", \"CLIENT_NAME\", \"CLIENT_LASTNAME\" FROM public.\"Client\";";
            try
            {
                using (NpgsqlConnection cn = new NpgsqlConnection(DBConfiguration.ConnectionString))
                {
                    if (cn.State == 0) cn.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sqlquery, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.CommandType = CommandType.Text;

                        NpgsqlDataReader dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            list = new List<Ent_Client>();
                            Ent_Client tipo = new Ent_Client();
                            while (dr.Read())
                            {
                                tipo = new Ent_Client();
                                tipo.Id = dr["CLIENT_ID"].ToString();
                                tipo.FirstName = dr["CLIENT_NAME"].ToString();
                                tipo.LastName = dr["CLIENT_LASTNAME"].ToString();
                                list.Add(tipo);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error en base de datos");
            }
            return list;
        }
    }
}
