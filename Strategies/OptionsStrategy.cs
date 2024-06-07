namespace TestOne.BinaryReader.Strategies
{
    public class OptionsStrategy : IStrategy
    {
        public OptionsStrategy(Dictionary<byte, string> options)
        {
            Options = options;
        }

        public OptionsStrategy()
        {
        }

        public Dictionary<byte, string> Options { get; set; }

        /// <summary>
        /// The default behavior for byte value
        /// </summary>
        public static OptionsStrategy Default = new OptionsStrategy()
        {
            Options = new Dictionary<byte, string>()
            {
                {0,"FALSE"},
                {1,"TRUE"}
            }
        };

        public string FallBack { get; set; } = "undefined";

        public string Resolve(byte value)
        {
            if (Options.ContainsKey(value))
                return Options[value];

            return FallBack;
        }
    }
}
