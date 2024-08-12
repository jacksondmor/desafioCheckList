namespace desafioCheckList.Core
{
    public class CheckList
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdVehicleType { get; set; }
        public required string Plate { get; set; }
        public required string DriverName { get; set; }
        public required string Approver { get; set; }
        public required string Status { get; set; }
        public int Approved { get; set; }
        public string? GeneralObservation { get; set; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public List<CheckListItem>? checkListItems { get; set; }
        public class FilterCheckList
        {
            public int? IdUser { get; set; }
            public int? IdVehicleType { get; set; }
            public string? Plate { get; set; }
            public string? Approver { get; set; }
            public string? Status { get; set; }
            public int? Approved { get; set; }
        }
        public class InsertCheckList
        {
            public int IdUser { get; set; }
            public int IdVehicleType { get; set; }
            public required string Plate { get; set; }
            public required string DriverName { get; set; }
            public required string Approver { get; set; }
            public string? GeneralObservation { get; set; }
        }
        public class UpdateCheckList
        {
            public string? Status { get; set; }
            public int? Approved { get; set; }
        }
    }
}
