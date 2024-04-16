using Express_Management.Data;
using Express_Management.Models.Contracts;

namespace Express_Management.Infrastructures.Repositories
{
    public interface IAuditColumnTransformer
    {
        Task TransformAsync(IHasAudit entity, ApplicationDbContext context);
    }
}
