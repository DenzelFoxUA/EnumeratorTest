using static System.Net.Mime.MediaTypeNames;

namespace EnumeratorTest
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var textCollection = new SomeCustomWordCollection(new[]{ "word1", "word2", "word3", "word4", "word5" });

            foreach (var s in textCollection)
            {
                Console.WriteLine($"{s}, ");
            }
        }
    }
}
