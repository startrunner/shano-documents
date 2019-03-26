using ShanoLibraries.Documents.DataModel;
using System;

namespace ShanoLibraries.Documents.Demo1
{
    struct Tags
    {
        public class OpeningBold { }
        public class ClosingBold { }
        public class OpeningItalic { }
        public class ClosingItalic { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IShanoDocument document = null;

            document.RegisterMatchingTagTypePair(typeof(Tags.OpeningBold), typeof(Tags.ClosingBold));
            document.RegisterMatchingTagTypePair(typeof(Tags.OpeningItalic), typeof(Tags.ClosingItalic));

            Console.WriteLine("Hello World!");
        }
    }
}
