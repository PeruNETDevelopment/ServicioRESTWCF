using System.Runtime.Serialization;

namespace PeruNETDevelopment.Rest.Errores
{
    [DataContract]
    public class ActividadException
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
    }
}