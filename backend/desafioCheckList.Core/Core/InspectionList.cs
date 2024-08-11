namespace desafioCheckList.Core.Core
{
    public class InspectionList
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public class FilterInspectionList
        {
            public string? Code { get; set; }
        }
    }
}
