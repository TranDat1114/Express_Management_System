using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Entities;

namespace Express_Management.Applications.VendorCategories
{
    public class VendorCategoryService : Repository<VendorCategory>
    {
        public VendorCategoryService(
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
