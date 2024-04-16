using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Entities;

namespace Express_Management.Applications.DeliveryOrders
{
    public class DeliveryOrderService : Repository<DeliveryOrder>
    {
        public DeliveryOrderService(
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
