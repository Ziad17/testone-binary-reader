using System.Globalization;
using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// used to resolve half word type
    /// </summary>
    /// <seealso cref="TestOne.BinaryReader.Allocations.Allocation" />
    public class HalfWordAllocation : Allocation
    {
        public HalfWordAllocation(int length, int start) : base(length, start)
        {
        }

        public override void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader)
        {
            fileStream.Seek(Start, SeekOrigin.Begin);

            var result = reader.ReadBytes(Length);

            var value = BitConverter.ToInt16(result, 0).ToString(CultureInfo.InvariantCulture);

            if (Strategy is null)
            {
                Value = value;
                return;
            }

            var valueStrategy = Strategy as ValueStrategy;

            if (valueStrategy == null)
            {
                Value = value;
                return;
            }

            var strategy = valueStrategy;

            Value = $"{value}{strategy.Label}";
        }
    }
}
