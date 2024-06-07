namespace TestOne.BinaryReader.Strategies
{
    public class ValueStrategy : IStrategy
    {
        public ValueStrategy(string label)
        {
            Label = label;
        }

        public string FallBack { get; set; } = "undefined";

        public string Label { get; set; }
    }
}
