using Express_Management.Data;
using Express_Management.Infrastructures.Repositories;
using Express_Management.Models.Contracts;
using Express_Management.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Express_Management.Applications.SalesOrders
{
    public class SalesOrderService : Repository<SalesOrder>
    {
        public SalesOrderService(
            ApplicationDbContext context,
            IHttpContextAccessor httpContextAccessor,
            IAuditColumnTransformer auditColumnTransformer) :
                base(
                    context,
                    httpContextAccessor,
                    auditColumnTransformer)
        {
        }


        public async Task RecalculateParentAsync(int? masterId)
        {

            var master = await _context.Set<SalesOrder>()
                .Include(x => x.Tax)
                .Where(x => x.Id == masterId && x.IsNotDeleted == true)
                .FirstOrDefaultAsync();

            var childs = await _context.Set<SalesOrderItem>()
                .Where(x => x.SalesOrderId == masterId && x.IsNotDeleted == true)
                .ToListAsync();

            if (master != null)
            {
                master.BeforeTaxAmount = 0;
                foreach (var item in childs)
                {
                    master.BeforeTaxAmount += item.Total;
                }
                if (master.Tax != null)
                {
                    master.TaxAmount = (master.Tax.Percentage / 100.0) * master.BeforeTaxAmount;
                }
                master.AfterTaxAmount = master.BeforeTaxAmount + master.TaxAmount;
                _context.Set<SalesOrder>().Update(master);
                await _context.SaveChangesAsync();
            }
        }



        public override async Task UpdateAsync(SalesOrder? entity)
        {
            if (entity != null)
            {
                if (entity is IHasAudit auditEntity && !string.IsNullOrEmpty(_userId))
                {
                    auditEntity.UpdatedByUserId = _userId;
                }
                if (entity is IHasAudit auditedEntity)
                {
                    auditedEntity.UpdatedAtUtc = DateTime.Now;
                }

                _context.Set<SalesOrder>().Update(entity);
                await _context.SaveChangesAsync();

                await RecalculateParentAsync(entity.Id);
            }
            else
            {
                throw new Exception("Unable to process, entity is null");
            }
        }

    }
}
