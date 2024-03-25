using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Runninghill.Sentence.Assessment.Infrastructure.Extentions
{
    internal static class AssemblyExtensions
    {
        public static string GetResourceAsString(this Assembly assembly, string fileName)
        {
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(fileName));
            if (resourceName == null) { throw new Exception("Filename cannot be null"); }
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
            {
                if (stream == null) { throw new Exception("Stream cannot be null"); }
                using (StreamReader reader = new StreamReader(stream))
                {
                    var strJson = reader.ReadToEnd();
                    return strJson;
                }
            }
        }
    }
}
