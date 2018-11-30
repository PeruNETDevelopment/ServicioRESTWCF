using PeruNETDevelopment.Rest.Dominio;
using PeruNETDevelopment.Rest.Errores;
using PeruNETDevelopment.Rest.Persistencia;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Web;

namespace PeruNETDevelopment.Rest
{
    public class Actividades : IActividades
    {
        private ActividadDAO actividadDAO = new ActividadDAO();

        public Actividad CrearActividad(Actividad actividadACrear)
        {
            Actividad actividadExistente = actividadDAO.Obtener(actividadACrear.nActividad);
            if (actividadExistente != null)
            {
                throw new WebFaultException<ActividadException>(new ActividadException()
                {
                    Codigo = 101,
                    Descripcion = "Actividad duplicada"
                }, HttpStatusCode.Conflict);
            }

            return actividadDAO.Crear(actividadACrear);
        }

        public Actividad ObtenerActividad(string nActividad)
        {
            return actividadDAO.Obtener(nActividad);
        }

        public Actividad ModificarActividad(Actividad actividadAModificar)
        {
            Actividad actividadExistente = actividadDAO.Obtener(actividadAModificar.nActividad);

            if (actividadExistente != null)
            {
                throw new WebFaultException<ActividadException>(new ActividadException()
                {
                    Codigo = 102,
                    Descripcion = "Actividad no existe"
                }, HttpStatusCode.Conflict);
            }

            return actividadDAO.Modificar(actividadAModificar);
        }

        public void EliminarActividad(string nActividad)
        {
            Actividad actividadExistente = actividadDAO.Obtener(nActividad);

            if (actividadExistente.sEstado != "C")
            {
                throw new WebFaultException<ActividadException>(new ActividadException()
                {
                    Codigo = 103,
                    Descripcion = "Actividad con movimientos"
                }, HttpStatusCode.Conflict);
            }

            actividadDAO.Eliminar(nActividad);
        }

        public List<Actividad> ListarActividades()
        {
            return actividadDAO.Listar();
        }

        public List<Actividad> ListarActividadesPorUsuarioEstado(string cUsuario, string sEstado)
        {
            Actividad validaUsuario = actividadDAO.ValidarUsuario(cUsuario);
            if (validaUsuario.sEstado == "I")
            {
                throw new WebFaultException<ActividadException>(new ActividadException()
                {
                    Codigo = 104,
                    Descripcion = "Usuario Inactivo"
                }, HttpStatusCode.Conflict);
            }
            return actividadDAO.ListarActividadesPorUsuarioEstado(cUsuario, sEstado);
        }
    }
}
