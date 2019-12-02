using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.TempoServico
{
    public class TempoServicoDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static List<TempoServico> GetTemposServico()
        {
            List<TempoServico> _TemposServico = new List<TempoServico>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDTEMPSERV, DESCTEMPSERV, VALORTEMPSERV FROM TEMPOSERVICO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var temposservico = new TempoServico();

                                temposservico.IDTEMPSERV = Convert.ToInt32(dr["IDTEMPSERV"]);
                                temposservico.DESCTEMPSERV = dr["DESCTEMPSERV"].ToString();
                                temposservico.VALORTEMPSERV = float.Parse(dr["VALORTEMPSERV"].ToString());
                                _TemposServico.Add(temposservico);
                            }
                        }
                        return _TemposServico;
                    }
                }
            }
        }

        public static TempoServico GetTempoServico(int id)
        {
            TempoServico temposervico = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDTEMPSERV, DESCTEMPSERV, VALORTEMPSERV FROM TEMPOSERVICO WHERE IDTEMPSERV = @IDTEMPSERV", con))
                {
                    cmd.Parameters.AddWithValue("@IDTEMPSERV", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                temposervico = new TempoServico();

                                temposervico.IDTEMPSERV = Convert.ToInt32(dr["IDTEMPSERV"]);
                                temposervico.DESCTEMPSERV = dr["DESCTEMPSERV"].ToString();
                                temposervico.VALORTEMPSERV = float.Parse(dr["VALORTEMPSERV"].ToString());
                            }
                        }
                        return temposervico;
                    }
                }
            }
        }
    }
}