using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.Servico
{
    public class ServicoDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static int InsertServico(Servico servico)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO SERVICO (VALORSERV, OPVOLSERV, OPTPCARGA, OPSERVEXTRA, OPTEMPSERV, OPADICIONAL, OPORIGEM, OPDESTINO) VALUES (@VALORSERV, @OPVOLSERV, @OPTPCARGA, @OPSERVEXTRA, @OPTEMPSERV, @OPADICIONAL, @OPORIGEM, @OPDESTINO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@VALORSERV", servico.VALORSERV);
                    cmd.Parameters.AddWithValue("@OPVOLSERV", servico.OPVOLSERV);
                    cmd.Parameters.AddWithValue("@OPTPCARGA", servico.OPTPCARGA);
                    cmd.Parameters.AddWithValue("@OPSERVEXTRA", servico.OPSERVEXTRA);
                    cmd.Parameters.AddWithValue("@OPTEMPSERV", servico.OPTEMPSERV);
                    cmd.Parameters.AddWithValue("@OPADICIONAL", servico.OPADICIONAL);
                    cmd.Parameters.AddWithValue("@OPORIGEM", servico.OPORIGEM);
                    cmd.Parameters.AddWithValue("@OPDESTINO", servico.OPDESTINO);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int DeleteServico(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM SERVICO WHERE IDSERVE = @IDSERV";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDSERV", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Servico> GetServicos()
        {
            List<Servico> _Servicos = new List<Servico>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSERV, VALORSERV, OPVOLSERV, OPTPCARGA, OPSERVEXTRA, OPTEMPSERV, OPADICIONAL, OPORIGEM, OPDESTINO FROM SERVICO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var servico = new Servico();

                                servico.IDSERV = Convert.ToInt32(dr["IDSERV"]);
                                servico.VALORSERV = float.Parse(dr["VALORSERV"].ToString());
                                servico.OPVOLSERV = dr["OPVOLSERV"].ToString();
                                servico.OPTPCARGA = dr["OPTPCARGA"].ToString();
                                servico.OPSERVEXTRA = dr["OPSERVEXTRA"].ToString();
                                servico.OPTEMPSERV = dr["OPTEMPSERV"].ToString();
                                servico.OPADICIONAL = dr["OPADICIONAL"].ToString();
                                servico.OPORIGEM = dr["OPORIGEM"].ToString();
                                servico.OPDESTINO = dr["OPDESTINO"].ToString();

                                _Servicos.Add(servico);
                            }
                        }
                        return _Servicos;
                    }
                }
            }
        }

        public static Servico GetServico(int id)
        {
            Servico servico = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDSERV, VALORSERV, OPVOLSERV, OPTPCARGA, OPSERVEXTRA, OPTEMPSERV, OPADICIONAL, OPORIGEM, OPDESTINO FROM SERVICO WHERE IDSERV = @IDSERV", con))
                {
                    cmd.Parameters.AddWithValue("@IDSERV", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                servico = new Servico();

                                servico.IDSERV = Convert.ToInt32(dr["IDSERV"]);
                                servico.VALORSERV = float.Parse(dr["VALORSERV"].ToString());
                                servico.OPVOLSERV = dr["OPVOLSERV"].ToString();
                                servico.OPTPCARGA = dr["OPTPCARGA"].ToString();
                                servico.OPSERVEXTRA = dr["OPSERVEXTRA"].ToString();
                                servico.OPTEMPSERV = dr["OPTEMPSERV"].ToString();
                                servico.OPADICIONAL = dr["OPADICIONAL"].ToString();
                                servico.OPORIGEM = dr["OPORIGEM"].ToString();
                                servico.OPDESTINO = dr["OPDESTINO"].ToString();
                            }
                        }
                        return servico;
                    }
                }
            }
        }
    }
}