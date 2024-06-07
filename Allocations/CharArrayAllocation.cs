using System.Text;

namespace TestOne.BinaryReader.Allocations
{
    public class CharArrayAllocation : Allocation
    {
        public CharArrayAllocation(int length, int start) : base(length, start)
        {
        }

        public override void Read(ref FileStream fileStream, ref System.IO.BinaryReader reader)
        {
            fileStream.Seek(Start, SeekOrigin.Begin);

            byte[] bytes = reader.ReadBytes(Length);

            Value = Encoding.ASCII.GetString(bytes).TrimEnd('\0').TrimStart('\0').TrimStart('\u0001');
        }
    }
}
