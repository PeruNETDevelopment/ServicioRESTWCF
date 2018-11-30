using PeruNETDevelopment.Rest.Dominio;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace PeruNETDevelopment.Rest
{
    [ServiceContract]
    public interface IActividades
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Actividades", ResponseFormat = WebMessageFormat.Json)]
        Actividad CrearActividad(Actividad actividadACrear);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Actividades/{nActividad}", ResponseFormat = WebMessageFormat.Json)]
        Actividad ObtenerActividad(string nActividad);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "Actividades", ResponseFormat = WebMessageFormat.Json)]
        Actividad ModificarActividad(Actividad actividadAModificar);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "Actividades/{nActividad}", ResponseFormat = WebMessageFormat.Json)]
        void EliminarActividad(string nActividad);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Actividades", ResponseFormat = WebMessageFormat.Json)]
        List<Actividad> ListarActividades();

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "Actividades/{cusuario}/{sestado}", ResponseFormat = WebMessageFormat.Json)]
        List<Actividad> ListarActividadesPorUsuarioEstado(string cUsuario, string sEstado);
    }
}
