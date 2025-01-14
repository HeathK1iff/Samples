using System.Text.Json;
using Samples.Bridge.Abstractions;

namespace Samples.Bridge.Implemetator
{
    // Implementation of Implementator #1
    public class JsonSerializator : Serializator
    {
        public override T Deserialize<T>(string text)
        {
            return JsonSerializer.Deserialize<T>(text);
        }

        public override string GetContentType()
        {
            return "json";
        }

        public override string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }
    }
}