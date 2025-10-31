using CoreWCF;

namespace HolaMundo_CoreWcf.Services
{
    [ServiceContract]
    public interface IGreatService
    {
        [OperationContract]
        string Great(string name);
    }
}
