namespace TestOne.BinaryReader
{
    /// <summary>
    /// extension to work on top of BinaryReader to read each allocation of a section
    /// </summary>
    public static class SectionExtensions
    {
        public static void AnalyzeSection(this System.IO.BinaryReader reader, ref FileStream fileStream, Section section)
        {
            foreach (var c in section.Allocations)
            {
                try
                {
                    c.Read(ref fileStream, ref reader);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

            }
        }
    }
}
