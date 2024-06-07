namespace TestOne.BinaryReader.Strategies
{
    /// <summary>
    /// a strategy defines what options are defined for each type of allocation to have
    /// interchangeable behaviors when reading different allocations
    /// </summary>
    public interface IStrategy
    {
        public string FallBack { get; set; }
    }
}
