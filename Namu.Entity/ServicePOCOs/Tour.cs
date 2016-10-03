namespace Namu.Entity.ServicePOCOs
{
    public class Tour : AuditableEntity
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public int DepartureTime_Hour { get; set; }
        public int DepartureTime_Minute { get; set; }
    
        public virtual ProviderTourType ProviderTour { get; set; }
    }
}
