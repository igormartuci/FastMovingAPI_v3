using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.VolumeServico
{
    public class VolumeServicoDAL
    {

        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static List<VolumeServico> GetVolumesServico()
        {
            List<VolumeServico> _VolumesServico = new List<VolumeServico>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDVOLSERV, DESCVOLSERV, VALORVOLSERV FROM VOLUMESERVICO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var volumeservico = new VolumeServico();

                                volumeservico.IDVOLSERV = Convert.ToInt32(dr["IDVOLSERV"]);
                                volumeservico.DESCVOLSERV = dr["DESCVOLSERV"].ToString();
                                volumeservico.VALORVOLSERV = float.Parse(dr["VALORVOLSERV"].ToString());
                                _VolumesServico.Add(volumeservico);
                            }
                        }
                        return _VolumesServico;
                    }
                }
            }
        }

        public static VolumeServico GetVolumeServico(int id)
        {
            VolumeServico volumeservico = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDVOLSERV, DESCVOLSERV, VALORVOLSERV FROM VOLUMESERVICO WHERE IDVOLSERV = @IDVOLSERV", con))
                {
                    cmd.Parameters.AddWithValue("@IDVOLSERV", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                volumeservico = new VolumeServico();

                                volumeservico.IDVOLSERV = Convert.ToInt32(dr["IDVOLSERV"]);
                                volumeservico.DESCVOLSERV = dr["DESCVOLSERV"].ToString();
                                volumeservico.VALORVOLSERV = float.Parse(dr["VALORVOLSERV"].ToString());
                            }
                        }
                        return volumeservico;
                    }
                }
            }
        }
    }
}