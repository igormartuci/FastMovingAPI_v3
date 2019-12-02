using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.TipoCarga
{
    public class TipoCargaDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static List<TipoCarga> GetTiposCarga()
        {
            List<TipoCarga> _TiposCarga = new List<TipoCarga>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDTPCARGA, DESCTPCARGA, VALORTPCARGA FROM TIPOCARGA", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var tiposcarga = new TipoCarga();

                                tiposcarga.IDTPCARGA = Convert.ToInt32(dr["IDTPCARGA"]);
                                tiposcarga.DESCTPCARGA = dr["DESCTPCARGA"].ToString();
                                tiposcarga.VALORTPCARGA = float.Parse(dr["VALORTPCARGA"].ToString());
                                _TiposCarga.Add(tiposcarga);
                            }
                        }
                        return _TiposCarga;
                    }
                }
            }
        }

        public static TipoCarga GetTipoCarga(int id)
        {
            TipoCarga tipocarga = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDTPCARGA, DESCTPCARGA, VALORTPCARGA FROM TIPOCARGA WHERE IDTPCARGA = @IDTPCARGA", con))
                {
                    cmd.Parameters.AddWithValue("@IDTPCARGA", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                tipocarga = new TipoCarga();

                                tipocarga.IDTPCARGA = Convert.ToInt32(dr["IDTPCARGA"]);
                                tipocarga.DESCTPCARGA = dr["DESCTPCARGA"].ToString();
                                tipocarga.VALORTPCARGA = float.Parse(dr["VALORTPCARGA"].ToString());
                            }
                        }
                        return tipocarga;
                    }
                }
            }
        }
    }
}