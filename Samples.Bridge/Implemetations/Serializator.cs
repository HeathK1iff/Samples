using Samples.Bridge.Abstractions;

namespace Samples.Bridge.Implemetations
{
    // Implementator
    public abstract class Serializator
    {
        public abstract string GetContentType();
        public abstract string Serialize<T>(T obj) where T : ServiceRequestBase;
        public abstract T Deserialize<T>(string text) where T : ServiceResponseBase;
    }

}