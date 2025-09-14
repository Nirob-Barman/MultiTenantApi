namespace MultiTenantApi.Services
{
    public class HostTenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public HostTenantService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
        }

        public string GetTenantConnectionName()
        {
            var host = _httpContextAccessor.HttpContext?.Request.Host.Host;

            if (string.IsNullOrEmpty(host))
                //throw new Exception("No host found in request.");
                return null!;

            var mapping = _configuration.GetSection("HostConnectionMapping")
                                        .Get<Dictionary<string, string>>();

            if (mapping != null && mapping.TryGetValue(host, out var connectionName))
            {
                return connectionName;
            }

            return mapping?["default"] ?? throw new Exception("Default connection not configured.");
        }
    }
}
