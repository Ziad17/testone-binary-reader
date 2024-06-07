using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// an abstract superclass of allocation to help facilitate subclasses initialization
    /// </summary>
    /// <seealso cref="TestOne.BinaryReader.Allocations.IAllocation" />
    public abstract class Allocation : IAllocation
    {
        protected Allocation(int length, int start)
        {
            Length = length;
            Start = start;
        }

        public void Reserve()
        {
            Reserved = true;
            Title = "Reserved";
        }

        public int Length { get; set; }

        public int Start { get; set; }

        public bool Reserved { get; set; }

        public string Title { get; set; }

        public string Value { get; set; }

        public IStrategy Strategy { get; set; }

        public abstract void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader);

        public Allocation WithTitle(string title)
        {
            Title = title;
            return this;
        }
    }
}
