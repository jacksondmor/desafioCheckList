namespace desafioCheckList.Core.Core
{
    public class CheckListItem
    {
        public int Id { get; set; }
        public int IdCheckList { get; set; }
        public int IdVehicle_InspectionList { get; set; }
        public int Status { get; set; }
        public required string Observation { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
