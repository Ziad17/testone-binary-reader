using TestOne.BinaryReader.Strategies;

namespace TestOne.BinaryReader.Maps
{
    /// <summary>
    /// This is a map which describes how the bytes in the files are located, determining how sections,
    /// allocations, and strategies interact to read values.
    /// </summary>
    public static class BasicMap
    {
        public static List<Section> BasicTests() => new List<Section>()
        {
            new Section("FLAG")
            .AllocateByte("Enable", 1, 0, OptionsStrategy.Default)
            .AllocateByte(6, 1)
            .AllocateByte("Available", 1, 7, OptionsStrategy.Default),

            new Section("HEADER")
                .AllocateCharArray("Manufacturer", 32, 8)
                .AllocateCharArray("Company", 32, 40)
                .AllocateCharArray("Station", 32, 72)
                .AllocateCharArray("Operator", 32, 104)
                .AllocateCharArray("Model", 32, 136)
                .AllocateCharArray("Serial", 32, 168)
                .AllocateCharArray("Version", 32, 200)
                .AllocateCharArray("Name", 33, 232)
                .AllocateByteArray(3, 265),

            new Section("TEST TYPE")
                .AllocateByte("Test Type", 1, 268, new Dictionary<byte, string>()
                {
                    { 0, "UNKNOWN" },
                    { 1, "Injection Test" },
                    { 2, "Ratio Test" },
                    { 3, "Auto Test" },
                })
                .AllocateByteArray(3, 269),

            new Section("START CONDITION PARAM")
                .AllocateByte("Type", 1, 272, new Dictionary<byte, string>()
                {
                    { 0, "Internal" },
                    { 1, "External" },
                    { 2, "Continuous" },
                })
                .AllocateByteArray(3, 273)
                .AllocateByte("Mode", 1, 276, new Dictionary<byte, string>()
                {
                    { 0, "Dry" },
                    { 1, "Wet" },
                })
                .AllocateByteArray(3, 277)
                .AllocateByte("Edge", 1, 280, new Dictionary<byte, string>()
                {
                    { 0, "NO" },
                    { 1, "NC" },
                    { 2, "AUTO" },
                })
                .AllocateByteArray(3, 281),

            new Section("STOP CONDITION PARAM")
                .AllocateByte("Type", 1, 284, new Dictionary<byte, string>()
                {
                    { 0, "Internal" },
                    { 1, "External" },
                    { 2, "Continuous" },
                })
                .AllocateByteArray(3, 285)
                .AllocateByte("Mode", 1, 288, new Dictionary<byte, string>()
                {
                    { 0, "Dry" },
                    { 1, "Wet" },
                })
                .AllocateByteArray(3, 289)
                .AllocateByte("Edge", 1, 292, new Dictionary<byte, string>()
                {
                    { 0, "NO" },
                    { 1, "NC" },
                    { 2, "AUTO" },
                })
                .AllocateByteArray(3, 293),

            new Section("PASS / FAIL PARAM")
                .AllocateByte("Enable", 1, 296)
                .AllocateByte(7, 297)
                .AllocateDouble("Upper Limit", 8, 304, "second")
                .AllocateDouble("Lower Limit", 8, 312, "second"),

            new Section("INJECTIO PARAM")
                .AllocateHalfWord("Current", 2, 320, "A")
                .AllocateByteArray(2, 322)
                .AllocateByte("Frequency", 1, 324, new Dictionary<byte, string>()
                {
                    { 0, "50Hz" },
                    { 1, "60Hz" }
                })
                .AllocateByteArray(2, 325)
                .AllocateByte("Frequency Value", 1, 328, "Hz")
                .AllocateByte("Turn Number", 1, 329)
                .AllocateByteArray(6, 330)
                .AllocateDouble("T max", 8, 336, "second"),

            new Section("RATIO TEST PARAM")
                .AllocateHalfWord("Primary", 2, 344)
                .AllocateHalfWord("Secondary", 2, 346)
                .AllocateByteArray(4, 348)
                .AllocateDouble("Value", 8, 352),

            new Section("AUTO TEST PARAM")
                .AllocateDouble("Current Start", 8, 360, "A")
                .AllocateDouble("Current Stop", 8, 368, "A")
                .AllocateDouble("Current Step", 8, 376, "A")
                .AllocateDouble("Current Delay", 8, 384, "second"),

            new Section("TEST STATE")
                .AllocateByte("Test State", 1, 392, new Dictionary<byte, string>()
                {
                    { 0, "IDLE" },
                    { 1, "WAIT START" },
                    { 2, "START" },
                    { 3, "CHECK" },
                    { 4, "POWER ON" },
                    { 5, "INJECTION" },
                    { 6, "POWER OFF" },
                    { 7, "SHUTDOWN" },
                    { 8, "STOP" },
                    { 9, "DONE" },
                    { 10, "CALIBRATION" },
                })
                .AllocateByteArray(3, 393),

            new Section("TEST STATUS")
                .AllocateByte("Test Status", 1, 396, new Dictionary<byte, string>()
                {
                    { 0, "READY" },
                    { 1, "OK" },
                    { 2, "CANCEL" },
                    { 3, "WAIT" },
                    { 4, "TIMEOUT" },
                    { 5, "CONTACT DETECT" },
                    { 6, "MEASUREMENT" },
                    { 7, "POWER ON" },
                    { 8, "RUN" },
                    { 9, "POWER OFF" },
                    { 10, "STOP" },
                    { 11, "DONE" },
                    { 12, "ERROR CONTROL" },
                    { 13, "ERROR EMERGENCY STOP" },
                    { 14, "ERROR CABLE" },
                    { 15, "ERROR SOURCE LIMIT" },
                    { 16, "ERROR SOURCE LIMIT" },
                    { 17, "ERROR OVER CURRENT" },
                    { 18, "ERROR HIGH TEMPERATURE" },
                    { 19, "ERROR AMP FAULT" },
                    { 20, "ERROR FAN FAULT" },
                    { 21, "ERROR HIGH GAIN" },
                })
                .AllocateByteArray(3, 397),

            new Section("DATE TIME")
                .AllocateByteArray("Date And Time", 12, 400, new int[] { 4, 2, 1, 1, 1, 1, 1, 1 })
                .AllocateByteArray(4, 412)
                .AllocateByteArray(16, 416),

            new Section("MEASUREMENT")
                .AllocateDouble("Time", 8, 432, "second")
                .AllocateDouble("Current Out", 8, 440, "A")
                .AllocateDouble("Current Primary", 8, 448, "A")
                .AllocateDouble("Current Secondary", 8, 456, "A")
                .AllocateDouble("Voltage Primary", 8, 464, "V")
                .AllocateDouble("Voltage Secondary", 8, 472, "V"),
        };

        public static List<Section> RatioTests()
        {
            var list = new List<Section>()
            {
                new Section("RATIO TEST")
                    .AllocateDouble("Ratio", 8, 480)
                    .AllocateDouble("Ratio Error", 8, 488),

                new Section("RATIO TEST RESULT")
                    .AllocateWord($"Test Count", 4, 496)
                    .AllocateByteArray(4, 500),
            };

            var initialStart = 504;

            for (var i = 0; i < 100; i++)
            {
                var ratioTestResult = new Section("RATIO TEST RESULT")
                    .AllocateDouble($"Current {i + 1}", 8, initialStart, "A")
                    .AllocateDouble($"Time {i + 1}", 8, initialStart + 8, "second")
                    .AllocateByte($"Status {i + 1}", 1, initialStart + 16)
                    .AllocateByteArray(7, initialStart + 17);

                list.Add(ratioTestResult);
                initialStart += 24;
            }

            return list;
        }
    }
}
