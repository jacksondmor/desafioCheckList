namespace desafioCheckList.Core.Core
{
    public class Vehicle_InspectionList
    {
        public int Id { get; set; }
        public int IdVehicleType { get; set; }
        public int IdInspectionList { get; set; }
        public string? Parameter { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int Actived { get; set; }
    }
}
