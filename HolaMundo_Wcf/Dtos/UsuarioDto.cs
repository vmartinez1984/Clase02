using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace HolaMundo_Wcf.Dtos
{
    [DataContract]
    public class UserDto
    {
        [DataMember]        
        public string Nombre { get; set; }

        [DataMember]
        public string PrimerApellido { get; set; }
    }
}