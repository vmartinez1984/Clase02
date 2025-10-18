using NotificacionServicio.Interfaces;
using System.Threading.Tasks;

namespace HolaMundo_Worker.Workers
{
    public class NotificacionWorker: IHostedService, IDisposable
    {
        private readonly ILogger<NotificacionWorker> _logger;
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public NotificacionWorker(ILogger<NotificacionWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public  Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            Task.Delay(1000).Wait();

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            _logger.LogInformation("Hola mundo");
            INotificacion notificacion = _scopeFactory.CreateAsyncScope().ServiceProvider.GetService<INotificacion>();

            await notificacion.EnviarPorCorreoAsync();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
