using DN.WebApi.Domain.Contracts;

namespace DN.WebApi.Domain.Entities.Multitenancy
{
    public class Tenant : AuditableEntity
    {
        public string Name { get; private set; }
        public string Key { get; private set; }
        public string AdminEmail { get; private set; }
        public string ConnectionString { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime ValidUpto { get; private set; }

        public Tenant(string name, string key, string adminEmail, string connectionString)
        {
            Name = name;
            Key = key;
            AdminEmail = adminEmail;
            ConnectionString = connectionString;
            IsActive = true;

            // Add Default 1 Month Validity for all new tenants. Something like a DEMO period for tenants.
            ValidUpto = DateTime.UtcNow.AddMonths(1);
        }

        protected Tenant()
        {

        }

        public void AddValidity(int months)
        {
            this.ValidUpto = this.ValidUpto.AddMonths(months);
        }

        public void Activate()
        {
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.IsActive = false;
        }
    }
}