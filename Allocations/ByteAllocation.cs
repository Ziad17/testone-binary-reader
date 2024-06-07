using System.Globalization;
using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// used to resolve byte type
    /// </summary>
    /// <seealso cref="TestOne.BinaryReader.Allocations.Allocation" />
    public class ByteAllocation : Allocation
    {
        public ByteAllocation(int length, int start) : base(length, start)
        {
        }

        public override void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader)
        {
            fileStream.Seek(Start, SeekOrigin.Begin);

            var bytes = reader.ReadBytes(Length);
            var result = bytes.First();

            if (Strategy is null)
            {
                Value = BitConverter.ToString(bytes, 0).ToString(CultureInfo.InvariantCulture);
                return;
            }

            if (Strategy is OptionsStrategy)
            {
                var strategy = (OptionsStrategy)Strategy;
                var textOutput = strategy.Resolve(result);
                Value = textOutput;
                return;
            }

            if (Strategy is ValueStrategy)
            {
                var value = BitConverter.ToString(bytes, 0).ToString(CultureInfo.InvariantCulture);

                var doubleStrategy = Strategy as ValueStrategy;

                if (doubleStrategy == null)
                    Value = value;

                var strategy = doubleStrategy;

                Value = $"{value} {strategy.Label}";
            }
        }

        static string Validate(byte value, Func<byte, string> validationMethod)
        {
            return validationMethod(value);
        }
    }
}
