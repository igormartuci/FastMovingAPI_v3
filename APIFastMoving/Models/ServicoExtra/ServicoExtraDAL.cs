using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.ServicoExtra
{
    public class ServicoExtraDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static List<ServicoExtra> GetServicosExtra()
        {
            List<ServicoExtra> _ServicosExtra = new List<ServicoExtra>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSERVEXTRA, DESCSERVEXTRA, VALORSERVEXTRA FROM SERVICOEXTRA", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var servicosextra = new ServicoExtra();

                                servicosextra.IDSERVEXTRA = Convert.ToInt32(dr["IDSERVEXTRA"]);
                                servicosextra.DESCSERVEXTRA = dr["DESCSERVEXTRA"].ToString();
                                servicosextra.VALORSERVEXTRA = float.Parse(dr["VALORSERVEXTRA"].ToString());
                                _ServicosExtra.Add(servicosextra);
                            }
                        }
                        return _ServicosExtra;
                    }
                }
            }
        }

        public static ServicoExtra GetServicoExtra(int id)
        {
            ServicoExtra servicoextra = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSERVEXTRA, DESCSERVEXTRA, VALORSERVEXTRA FROM SERVICOEXTRA WHERE IDSERVEXTRA = @IDSERVEXTRA", con))
                {
                    cmd.Parameters.AddWithValue("@IDSERVEXTRA", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                servicoextra = new ServicoExtra();

                                servicoextra.IDSERVEXTRA = Convert.ToInt32(dr["IDSERVEXTRA"]);
                                servicoextra.DESCSERVEXTRA = dr["DESCSERVEXTRA"].ToString();
                                servicoextra.VALORSERVEXTRA = float.Parse(dr["VALORSERVEXTRA"].ToString());
                            }
                        }
                        return servicoextra;
                    }
                }
            }
        }
    }
}