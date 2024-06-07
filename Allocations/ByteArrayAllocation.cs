using System.Globalization;
using System.Text;
using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Allocations
{
    /// <summary>
    /// used to resolve byte array type
    /// </summary>
    /// <seealso cref="TestOne.BinaryReader.Allocations.Allocation" />
    public class ByteArrayAllocation : Allocation
    {
        public ByteArrayAllocation(int length, int start) : base(length, start)
        {
        }


        public override void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader)
        {
            if (Strategy == null)
            {
                return;
            }

            if (Strategy is DateTimeStrategy)
            {
                var dateTimeStrategy = (DateTimeStrategy)Strategy;

                var initialStart = Start;

                fileStream.Seek(initialStart, SeekOrigin.Begin);

                var unixTime = reader.ReadBytes(dateTimeStrategy.DateTimeParts[0]);
                var unixTimeString = Encoding.ASCII.GetString(unixTime).TrimEnd('\0');

                var year = reader.ReadBytes(dateTimeStrategy.DateTimeParts[1]);
                var yearString = BitConverter.ToInt16(year, 0).ToString(CultureInfo.InvariantCulture);

                var month = reader.ReadBytes(dateTimeStrategy.DateTimeParts[2]).First();

                var day = reader.ReadBytes(dateTimeStrategy.DateTimeParts[3]).First();

                var hour = reader.ReadBytes(dateTimeStrategy.DateTimeParts[4]).First();

                var minute = reader.ReadBytes(dateTimeStrategy.DateTimeParts[5]).First();

                var second = reader.ReadBytes(dateTimeStrategy.DateTimeParts[6]).First();

                var dayOfWeek = reader.ReadBytes(dateTimeStrategy.DateTimeParts[7]).First();

                var dateTime = new DateTime(int.Parse(yearString),
                    Convert.ToInt32(month),
                    Convert.ToInt32(day),
                    Convert.ToInt32(hour),
                    Convert.ToInt32(minute),
                    Convert.ToInt32(second));

                Value = $"{dateTime:G} {(DayOfWeek)Convert.ToInt32(dayOfWeek)} {unixTimeString}";
            }
        }
    }
}
