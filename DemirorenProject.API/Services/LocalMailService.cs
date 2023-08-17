namespace DemirorenProject.API.Services
{
    public class LocalMailService
    {
        private string _mailto = "admin@mycompany.com";
        private string _mailfrom = "noreply@mycompany.com";

        public void Send(string subject, string message)
        {
            Console.WriteLine($"mail from {_mailfrom} to {_mailto} with {nameof(LocalMailService)}" );

        }
    }
}
