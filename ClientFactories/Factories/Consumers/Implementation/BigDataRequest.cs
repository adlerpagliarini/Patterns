using System;

namespace ClientFactories.Factories.Consumers.Implementation
{
    public class BigDataRequest : Request
    {
        public string Input { get; set; }
    }

    public class Request
    {
        public DateTime DateTime => DateTime.Now;
    }
}
