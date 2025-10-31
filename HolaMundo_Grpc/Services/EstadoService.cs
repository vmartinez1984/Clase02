using Grpc.Core;
using HolaMundo_Grpc;

namespace HolaMundo_Grpc.Services
{
    public class EstadoService : Estado.EstadoBase
    {
        private readonly ILogger<EstadoService> _logger;
        public EstadoService(ILogger<EstadoService> logger)
        {
            _logger = logger;
        }

        public override Task<EstadosReply> ObtenerTodos(EstadoRequest estadoRequest, ServerCallContext context)
        {
            EstadosReply reply = new EstadosReply();

            reply.Estados.Add(new EstadoMessage { Id = 1, Nombre = "Activo" });            
            //reply.Estados.Add(new EstadoDto { Id = 2, Nombre = "Inactivo" });
            //reply.Estados.Add(new EstadoDto { Id = 3, Nombre = "Pendiente" });
            return Task.FromResult(reply);
        }
    }
}
