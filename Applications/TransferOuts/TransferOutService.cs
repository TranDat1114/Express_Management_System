using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Entities;

namespace Express_Management.Applications.TransferOuts
{
    public class TransferOutService : Repository<TransferOut>
    {
        public TransferOutService(
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
