using TestOne.BinaryReader.Allocations;
using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader
{
    /// <summary>
    /// a section hold a set of allocations to define a stage of reading, with a set of allocation methods
    /// to help build a map with more scalability, flexibility, and maintainability
    /// </summary>
    public class Section
    {
        public Section(string name)
        {
            Name = name;
            Allocations = new List<IAllocation>();
        }

        public string Name { get; set; }

        public List<IAllocation> Allocations { get; set; }

        public Section AllocateByte(string title, int length, int start, IStrategy optionsStrategy)
        {
            var allocation = new ByteAllocation(length, start).WithTitle(title);
            allocation.Strategy = optionsStrategy;
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateByte(string title, int length, int start)
        {
            var allocation = new ByteAllocation(length, start).WithTitle(title);
            allocation.Strategy = OptionsStrategy.Default;
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateByte(string title, int length, int start, Dictionary<byte, string> options)
        {
            return AllocateByte(title, length, start, new OptionsStrategy(options));
        }

        public Section AllocateByte(string title, int length, int start, string label)
        {
            return AllocateByte(title, length, start, new ValueStrategy(label));
        }

        public Section AllocateByte(int length, int start)
        {
            var allocation = new ByteAllocation(length, start);
            allocation.Reserve();
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateDouble(string title, int length, int start, string label)
        {
            var allocation = new DoubleAllocation(length, start).WithTitle(title);
            allocation.Strategy = new ValueStrategy(label);
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateDouble(string title, int length, int start)
        {
            var allocation = new DoubleAllocation(length, start).WithTitle(title);
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateWord(string title, int length, int start)
        {
            var allocation = new WordAllocation(length, start).WithTitle(title);
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateHalfWord(string title, int length, int start, string label)
        {
            var allocation = new HalfWordAllocation(length, start).WithTitle(title);
            allocation.Strategy = new ValueStrategy(label);
            Allocations.Add(allocation);
            return this;
        }
        public Section AllocateHalfWord(string title, int length, int start)
        {
            var allocation = new HalfWordAllocation(length, start).WithTitle(title);
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateByteArray(string title, int length, int start, int[] dateTimeParts)
        {
            var strategy = new DateTimeStrategy(dateTimeParts);
            var allocation = new ByteArrayAllocation(length, start).WithTitle(title);
            allocation.Strategy = strategy;
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateByteArray(int length, int start)
        {
            var allocation = new ByteArrayAllocation(length, start);
            allocation.Reserve();
            Allocations.Add(allocation);
            return this;
        }

        public Section AllocateCharArray(string title, int length, int start)
        {
            Allocations.Add(new CharArrayAllocation(length, start).WithTitle(title));
            return this;
        }
    }
}
