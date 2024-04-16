using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Entities;

namespace Express_Management.Applications.Vendors
{
    public class VendorService : Repository<Vendor>
    {
        public VendorService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IAuditColumnTransformer auditColumnTransformer) :
                base(
                    context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
        }


    }
}
