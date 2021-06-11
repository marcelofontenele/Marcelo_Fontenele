using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.RabbitMQ.Interfaces
{
    public interface IMqPublisher : IDisposable
    {
        void Publish(string exchange, object message);
    }
}
