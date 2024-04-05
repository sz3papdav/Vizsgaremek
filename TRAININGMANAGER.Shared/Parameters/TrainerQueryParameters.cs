namespace TRAININGMANAGER.Shared.Parameters
{
    public class TrainerQueryParameters
    {
        public uint MinYearOfBirth { get; set; }
        public uint MaxYearOfBirth { get; set; } = (uint)DateTime.Now.Year;
        public string Name { get; set; } = string.Empty;

        public bool ValidYearRange => MaxYearOfBirth > MinYearOfBirth;
    }
}
