namespace desafioCheckList.Core
{
    public class CheckListItem
    {
        public int Id { get; set; }
        public int IdCheckList { get; set; }
        public int IdVehicle_InspectionList { get; set; }
        public int? Status { get; set; }
        public string? Observation { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public class FilterCheckListItem
        {
            public int? IdCheckList { get; set; }
            public int? IdVehicle_InspectionList { get; set; }
            public int? Status { get; set; }
        }
        public class UpdateCheckListItem
        {
            public int IdCheckList { get; set; }
            public int Status { get; set; }
            public string? Observation { get; set; }
        }
    }
}
