using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// an allocation represent a predefined area of bytes in a file or a device, an allocation uses
    /// a strategy to resolve its value depending on each allocation implementation
    /// </summary>
    public interface IAllocation
    {
        public int Length { get; set; }

        public int Start { get; set; }

        public bool Reserved { get; set; }

        public string Value { get; set; }

        public string Title { get; set; }

        public IStrategy Strategy { get; set; }

        void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader);
    }
}
