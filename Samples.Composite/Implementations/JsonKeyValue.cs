using System.IO;
using System.Text;
using Samples.Composite.Interfaces;

namespace Samples.Composite.Implementations
{
    public class JsonKeyValue : IKeyValuePair
    {
        private string _key;
        private string _value;
        public JsonKeyValue(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public void Print(IKeyValuePairWriter printer)
        {
            printer.Write($"{_key}:{_value}");
        }
    }
}