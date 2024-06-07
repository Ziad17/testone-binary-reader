namespace TestOne.BinaryReader.Strategies
{
    public class DateTimeStrategy : IStrategy
    {
        public DateTimeStrategy(int[] dateTimeParts)
        {
            if (dateTimeParts.Length < 8)
                throw new InvalidDataException("the array that describes datetime components must have 8 elements");

            DateTimeParts = dateTimeParts;
        }

        public string FallBack { get; set; }

        public int[] DateTimeParts { get; set; }
    }
}
