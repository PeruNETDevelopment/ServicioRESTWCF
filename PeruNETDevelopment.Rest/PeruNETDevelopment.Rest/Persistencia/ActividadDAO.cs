using PeruNETDevelopment.Rest.Dominio;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PeruNETDevelopment.Rest.Persistencia
{

    public class ActividadDAO
    {
        private string CadenaConexion = "Data Source=DESKTOP-F4VV2GP\\SQLEXPRESS;Initial Catalog=DB_DSD_GOV;User ID=sa;Password=123;";

        public Actividad Crear(Actividad actividadACrear)
        {
            Actividad actividadCreada = null;
            string sql = "Insert into actividad (nActividad, cCliente, cUsuario, cTipoActividad, dDescripcion, dAsunto) " +
                "values(@nactividad, @ccliente, @cusuario, @ctipoactividad, @ddescripcion, @dasunto)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nactividad", actividadACrear.nActividad));
                    comando.Parameters.Add(new SqlParameter("@ccliente", actividadACrear.cCliente));
                    comando.Parameters.Add(new SqlParameter("@cusuario", actividadACrear.cUsuario));
                    comando.Parameters.Add(new SqlParameter("@ctipoactividad", actividadACrear.cTipoActividad));
                    comando.Parameters.Add(new SqlParameter("@ddescripcion", actividadACrear.dDescripcion));
                    comando.Parameters.Add(new SqlParameter("@dasunto", actividadACrear.dAsunto));
                    comando.ExecuteNonQuery();
                }
            }
            actividadCreada = Obtener(actividadACrear.nActividad);
            return actividadCreada;
        }

        public Actividad Obtener(string nActividad)
        {
            Actividad actividadEncontrada = null;
            string sql = "select * from actividad where nActividad = @nactividad";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nactividad", nActividad));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            actividadEncontrada = new Actividad()
                            {
                                nActividad = (string)resultado["nactividad"],
                                cCliente = (string)resultado["cCliente"],
                                cUsuario = (string)resultado["cUsuario"],
                                cTipoActividad = (string)resultado["cTipoActividad"],
                                dDescripcion = (string)resultado["dDescripcion"],
                                dAsunto = (string)resultado["dAsunto"],
                                sEstado = (string)resultado["sEstado"],
                            };
                        }
                    }
                }

            }
            return actividadEncontrada;
        }

        public Actividad Modificar(Actividad actividadAModificar)
        {
            Actividad actividadModificada = null;
            string sql = "update actividad set ctipoactividad = @ctipoactividad, ddescripcion = @ddescripcion, " +
                "dasunto = @dasunto, sestado = @sestado where nactividad = @nactividad";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@ctipoactividad", actividadAModificar.cTipoActividad));
                    comando.Parameters.Add(new SqlParameter("@ddescripcion", actividadAModificar.dDescripcion));
                    comando.Parameters.Add(new SqlParameter("@dasunto", actividadAModificar.dAsunto));
                    comando.Parameters.Add(new SqlParameter("@sestado", actividadAModificar.sEstado));
                    comando.Parameters.Add(new SqlParameter("@nactividad", actividadAModificar.nActividad));
                    comando.ExecuteNonQuery();
                }
            }
            actividadModificada = Obtener(actividadAModificar.nActividad);
            return actividadModificada;
        }

        public void Eliminar(string nActividad)
        {
            string sql = "delete from actividad where nActividad = @nactividad";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nactividad", nActividad));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Actividad> Listar()
        {
            List<Actividad> actividadesEncontradas = new List<Actividad>();
            Actividad actividadEncontrada = null;
            string sql = "select * from actividad";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            actividadEncontrada = new Actividad()
                            {
                                nActividad = (string)resultado["nactividad"],
                                cCliente = (string)resultado["cCliente"],
                                cUsuario = (string)resultado["cUsuario"],
                                cTipoActividad = (string)resultado["cTipoActividad"],
                                dDescripcion = (string)resultado["dDescripcion"],
                                dAsunto = (string)resultado["dAsunto"],
                                sEstado = (string)resultado["sEstado"]
                            };
                            actividadesEncontradas.Add(actividadEncontrada);
                        }
                    }
                }

            }

            return actividadesEncontradas;
        }

        public List<Actividad> ListarActividadesPorUsuarioEstado(string cUsuario, string sEstado)
        {
            List<Actividad> actividadesEncontradas = new List<Actividad>();
            Actividad actividadEncontrada = null;
            string sql = "select * from actividad where cusuario = @cusuario and sestado = @sestado";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cusuario", cUsuario));
                    comando.Parameters.Add(new SqlParameter("@sestado", sEstado));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            actividadEncontrada = new Actividad()
                            {
                                nActividad = (string)resultado["nactividad"],
                                cCliente = (string)resultado["cCliente"],
                                cUsuario = (string)resultado["cUsuario"],
                                cTipoActividad = (string)resultado["cTipoActividad"],
                                dDescripcion = (string)resultado["dDescripcion"],
                                dAsunto = (string)resultado["dAsunto"],
                                sEstado = (string)resultado["sEstado"]
                            };
                            actividadesEncontradas.Add(actividadEncontrada);
                        }
                    }
                }

            }

            return actividadesEncontradas;
        }

        public Actividad ValidarUsuario(string cUsuario)
        {
            Actividad actividadEncontrada = null;
            string sql = "select * from usuario where cusuario = @cusuario";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@cusuario", cUsuario));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            actividadEncontrada = new Actividad()
                            {
                                sEstado = (string)resultado["sEstado"],
                            };
                        }
                    }
                }

            }
            return actividadEncontrada;
        }
    }
}