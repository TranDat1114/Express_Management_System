using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Entities;

namespace Express_Management.Applications.AdjustmentPluss
{
    public class AdjustmentPlusService : Repository<AdjustmentPlus>
    {
        public AdjustmentPlusService(
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
