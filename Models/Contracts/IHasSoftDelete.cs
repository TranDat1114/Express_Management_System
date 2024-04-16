namespace Express_Management.Models.Contracts
{
    public interface IHasSoftDelete
    {
        bool IsNotDeleted { get; set; }
    }
}
