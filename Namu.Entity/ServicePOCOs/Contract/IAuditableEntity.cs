namespace Namu.Entity.ServicePOCOs.Contract
{
    public interface IAuditableEntity
    {
        int Id { get; set; }
        int UserId { get; set; }
    }
}
