namespace HolaMundo_CoreWcf.Services
{
    public class GreatService : IGreatService
    {
        public string Great(string name)
        {
           return $"Hello, {name}!";
        }
    }
}
