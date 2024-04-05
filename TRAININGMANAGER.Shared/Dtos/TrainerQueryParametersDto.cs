namespace TRAININGMANAGER.Shared.Dtos
{
    public class TrainerQueryParametersDto
    {
        public uint MinYearOfBirth { get; set; }
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public string Name { get; set; } = string.Empty;
    }
}
