using System.Runtime.Serialization;

namespace PeruNETDevelopment.Rest.Dominio
{
    [DataContract]
    public class Actividad
    {
        [DataMember]
        public string nActividad { get; set; }
        [DataMember]
        public string cCliente { get; set; }
        [DataMember]
        public string cUsuario { get; set; }
        [DataMember]
        public string cTipoActividad { get; set; }
        [DataMember]
        public string dDescripcion { get; set; }
        [DataMember]
        public string dAsunto { get; set; }
        [DataMember]
        public string sEstado { get; set; }

    }
}