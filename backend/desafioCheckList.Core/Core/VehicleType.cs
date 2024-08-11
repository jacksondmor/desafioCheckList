namespace desafioCheckList.Core.Core
{
    public class VehicleType
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Description { get; set; }
        public class FilterVehicleType
        {
            public string? Code { get; set; }
        }
    }
}
