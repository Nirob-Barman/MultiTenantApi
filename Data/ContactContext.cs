using Microsoft.EntityFrameworkCore;
using MultiTenantApi.Models;
using MultiTenantApi.Services;

namespace MultiTenantApi.Data
{
    public class ContactContext : DbContext
    {
        private readonly ITenantService? _tenantService;
        private readonly IConfiguration? _configuration;

        public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
        {
            // For design-time (no tenantService or configuration)
        }

        public ContactContext(
            DbContextOptions<ContactContext> options,
            IConfiguration configuration,
            ITenantService tenantService)
        {
            _configuration = configuration;
            _tenantService = tenantService;
        }


        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_tenantService != null && _configuration != null)
            {
                var tenant = _tenantService.GetTenantConnectionName();
                if (tenant != null)
                {
                    var conn = _configuration.GetConnectionString(tenant);
                    optionsBuilder.UseSqlServer(conn);
                }
                else
                {
                    // Fallback to a default connection string or throw an exception
                    var defaultConn = _configuration.GetConnectionString("DefaultConnection");
                    optionsBuilder.UseSqlServer(defaultConn);
                }
            }
        }
    }
}
