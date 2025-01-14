using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace Samples.Serialization.Entity
{
    [Serializable]
    public sealed class Address : ISerializable
    {
        public string Street { get; set; }
        public int BuildNo { get; set; }

        public Address()
        {
            
        }

        private Address(SerializationInfo info, StreamingContext context)
        {
            Trace.TraceInformation("Custom deserilization");
            Street = info.GetString("Street_Name");
            Trace.TraceInformation($"Street={Street}");
            BuildNo = info.GetInt32("Street_BuildNo");
            Trace.TraceInformation($"BuildNo={BuildNo}");
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Trace.TraceInformation("Custom serilization");
            info.AddValue("Street_Name", Street);
            Trace.TraceInformation($"Street_Name={Street}");
            info.AddValue("Street_BuildNo", BuildNo);
            Trace.TraceInformation($"Street_BuildNo={BuildNo}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Street={Street}");
            sb.Append($"&BuildNo={BuildNo}");
            return sb.ToString();
        }
    }
}
