using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APIFastMoving.Models.Usuarios
{
    public class UsuarioDAL
    {
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["FASTMOVING"].ConnectionString;
        }

        public static int InsertUsuario(Usuario usuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "INSERT INTO USUARIO (EMAILUSU, SENHAUSU, CPFUSU, NOMEUSU, SOBRENOMEUSU, DATANASCUSU, NRCARTAO, NMCARTAO, CVVCARTAO, DTVALCARTAO) VALUES (@EMAILUSU, @SENHAUSU, @CPFUSU, @NOMEUSU, @SOBRENOMEUSU, @DATANASCUSU, @NRCARTAO, @NMCARTAO, @CVVCARTAO, @DTVALCARTAO)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@EMAILUSU", usuario.EMAILUSU);
                    cmd.Parameters.AddWithValue("@SENHAUSU", usuario.SENHAUSU);
                    cmd.Parameters.AddWithValue("@CPFUSU", usuario.CPFUSU);
                    cmd.Parameters.AddWithValue("@NOMEUSU", usuario.NMCARTAO);
                    cmd.Parameters.AddWithValue("@SOBRENOMEUSU", usuario.SOBRENOMEUSU);
                    cmd.Parameters.AddWithValue("@DATANASCUSU", usuario.DATANASCUSU);
                    cmd.Parameters.AddWithValue("@NRCARTAO", usuario.NRCARTAO);
                    cmd.Parameters.AddWithValue("@NMCARTAO", usuario.NMCARTAO);
                    cmd.Parameters.AddWithValue("@CVVCARTAO", usuario.CVVCARTAO);
                    cmd.Parameters.AddWithValue("@DTVALCARTAO", usuario.DTVALCARTAO);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static int UpdateUsuario(Usuario usuario)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "UPDATE USUARIO SET EMAILUSU = @EMAILUSU, SENHAUSU = @SENHAUSU, NMCARTAO = @NMCARTAO, NRCARTAO = @NRCARTAO, DTVALCARTAO = @DTVALCARTAO, CVVCARTAO = @CVVCARTAO WHERE IDUSU = @IDUSU ";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSU", usuario.IDUSU);
                    cmd.Parameters.AddWithValue("@EMAILUSU", usuario.EMAILUSU);
                    cmd.Parameters.AddWithValue("@SENHAUSU", usuario.SENHAUSU);
                    cmd.Parameters.AddWithValue("@NMCARTAO", usuario.NMCARTAO);
                    cmd.Parameters.AddWithValue("@NRCARTAO", usuario.NRCARTAO);
                    cmd.Parameters.AddWithValue("@DTVALCARTAO", usuario.DTVALCARTAO);
                    cmd.Parameters.AddWithValue("@CVVCARTAO", usuario.CVVCARTAO);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }
        public static int DeleteUsuario(int id)
        {
            int reg = 0;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                string sql = "DELETE FROM USUARIO WHERE IDUSU = @IDUSU";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@IDUSU", id);

                    con.Open();
                    reg = cmd.ExecuteNonQuery();
                    con.Close();
                }
                return reg;
            }
        }

        public static List<Usuario> GetUsuarios()
        {
            List<Usuario> _Usuarios = new List<Usuario>();

            using (SqlConnection con = new SqlConnection(GetStringConexao()))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSU, EMAILUSU, CPFUSU, NOMEUSU, SOBRENOMEUSU, DATANASCUSU, NRCARTAO, NMCARTAO, CVVCARTAO, DTVALCARTAO FROM USUARIO", con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                var usuario = new Usuario();

                                usuario.IDUSU = Convert.ToInt32(dr["IDUSU"]);
                                usuario.EMAILUSU = dr["EMAILUSU"].ToString();
                                usuario.CPFUSU = dr["CPFUSU"].ToString();
                                usuario.NOMEUSU = dr["NOMEUSU"].ToString();
                                usuario.SOBRENOMEUSU = dr["SOBRENOMEUSU"].ToString();
                                usuario.DATANASCUSU = dr["DATANASCUSU"].ToString();
                                usuario.NRCARTAO = dr["NRCARTAO"].ToString();
                                usuario.NMCARTAO = dr["NMCARTAO"].ToString();
                                usuario.CVVCARTAO = Convert.ToInt32(dr["CVVCARTAO"]);
                                usuario.DTVALCARTAO = dr["DTVALCARTAO"].ToString();

                                _Usuarios.Add(usuario);
                            }
                        }
                        return _Usuarios;
                    }
                }
            }
        }

        public static Usuario GetUsuario(int id)
        {
            Usuario usuario = null;
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSU, EMAILUSU, CPFUSU, NOMEUSU, SOBRENOMEUSU, DATANASCUSU, NRCARTAO, NMCARTAO, CVVCARTAO, DTVALCARTAO FROM USUARIO WHERE IDUSU = @IDUSU", con))
                {
                    cmd.Parameters.AddWithValue("@IDUSU", id);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                usuario = new Usuario();

                                usuario.IDUSU = Convert.ToInt32(dr["IDUSU"]);
                                usuario.EMAILUSU = dr["EMAILUSU"].ToString();
                                usuario.CPFUSU = dr["CPFUSU"].ToString();
                                usuario.NOMEUSU = dr["NOMEUSU"].ToString();
                                usuario.SOBRENOMEUSU = dr["SOBRENOMEUSU"].ToString();
                                usuario.DATANASCUSU = dr["DATANASCUSU"].ToString();
                                usuario.NRCARTAO = dr["NRCARTAO"].ToString();
                                usuario.NMCARTAO = dr["NMCARTAO"].ToString();
                                usuario.CVVCARTAO = Convert.ToInt32(dr["CVVCARTAO"]);
                                usuario.DTVALCARTAO = dr["DTVALCARTAO"].ToString();
                            }
                        }
                        return usuario;
                    }
                }
            }
        }

        public static Usuario PostLogin(Usuario usuario)
        {
            using (SqlConnection con = new SqlConnection(GetStringConexao()))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT IDUSU, EMAILUSU, CPFUSU, NOMEUSU, SOBRENOMEUSU, DATANASCUSU, NRCARTAO, NMCARTAO, CVVCARTAO, DTVALCARTAO FROM USUARIO WHERE EMAILUSU = @EMAILUSU AND SENHAUSU = @SENHAUSU", con))
                {
                    cmd.Parameters.AddWithValue("@EMAILUSU", usuario.EMAILUSU);
                    cmd.Parameters.AddWithValue("@SENHAUSU", usuario.SENHAUSU);

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                usuario = new Usuario();

                                usuario.IDUSU = Convert.ToInt32(dr["IDUSU"]);
                                usuario.EMAILUSU = dr["EMAILUSU"].ToString();
                                usuario.CPFUSU = dr["CPFUSU"].ToString();
                                usuario.NOMEUSU = dr["NOMEUSU"].ToString();
                                usuario.SOBRENOMEUSU = dr["SOBRENOMEUSU"].ToString();
                                usuario.DATANASCUSU = dr["DATANASCUSU"].ToString();
                                usuario.NRCARTAO = dr["NRCARTAO"].ToString();
                                usuario.NMCARTAO = dr["NMCARTAO"].ToString();
                                usuario.CVVCARTAO = Convert.ToInt32(dr["CVVCARTAO"]);
                                usuario.DTVALCARTAO = dr["DTVALCARTAO"].ToString();
                            }
                        }
                        return usuario;
                    }
                }
            }
        }
    }
}