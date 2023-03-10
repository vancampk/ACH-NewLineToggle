namespace ACHToggle
{
    using System.Text;
    class Program
    {
        public const int lineSize = 94;
        static void Main(string[] args)
        {
            // C:\Users\vanca\Documents\GitHub\ACH-NewLineToggle\bin\Debug\net7.0\add_line_breaks.ach
            // Read File
            // Console.WriteLine("Please enter in file path to format...");
            string file = args.ToList().First() ?? string.Empty;
            args.ToList().ForEach(a => Console.WriteLine(a));
            if (File.Exists(file))
            {
                Console.WriteLine("--------------------Processing file--------------------");
                Console.WriteLine(file);
                Console.WriteLine("-------------------------------------------------------");

                // Read File
                string text = System.IO.File.ReadAllText(file);
                var lines = text.Split('\n').ToList();
                if (lines.Count == 1)
                {
                    // Add Line Breaks
                    var newLines = Enumerable.Range(0, lines[0].Length / lineSize).Select(x => lines[0].Substring(x * lineSize, lineSize)).ToList();
                    File.WriteAllLines(file, newLines);
                    Console.WriteLine("Added Line Breaks");
                }
                else
                {
                    // Remove Line Breaks
                    File.WriteAllText(file, text.Replace(System.Environment.NewLine, string.Empty));
                    Console.WriteLine("Removed All Line Breaks");
                }
            }
            else
            {
                Console.WriteLine("File Not Found!");
            }
        }
    }
}