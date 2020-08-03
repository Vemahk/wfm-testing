using System.Collections.Generic;
using Domain.Models.Orders;

namespace Domain.Models
{
    public class RootPayload
    {
        public RootPayload()
        {
        }

        public List<Payload> Payloads { get; } = new List<Payload>();
    }
}