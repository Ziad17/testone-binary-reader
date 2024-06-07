using System.Globalization;
using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// used to resolve double type
    /// </summary>
    /// <seealso cref="TestOne.BinaryReader.Allocations.Allocation" />
    public class DoubleAllocation : Allocation
    {
        public DoubleAllocation(int length, int start) : base(length, start)
        {
        }

        public override void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader)
        {
            fileStream.Seek(Start, SeekOrigin.Begin);

            byte[] bytes = reader.ReadBytes(Length);

            var value = BitConverter.ToDouble(bytes, 0).ToString(CultureInfo.InvariantCulture);

            if (Strategy == null)
            {
                Value = value;
                return;
            }

            var doubleStrategy = Strategy as ValueStrategy;

            if (doubleStrategy == null)
            {
                Value = value;
                return;
            }

            var strategy = doubleStrategy;

            Value = $"{value} {strategy.Label}";
        }
    }
}
