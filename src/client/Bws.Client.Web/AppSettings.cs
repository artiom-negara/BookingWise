namespace Bws.Client.Web
{
    public class AppSettings
    {
        public ApiSettings ApiSettings { get; set; } = new ApiSettings();
    }

    public class ApiSettings
    {
        public string? BaseUrl { get; set; }
    }
}
