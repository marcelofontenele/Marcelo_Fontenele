using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.RabbitMQ.Interfaces
{
    public interface IMqSubscriber : IDisposable
    {
        void Subscribe(string exchange, Action<string> callback);
        //void SubscribeAsync(Func<string, IDictionary<string, object>, Task<bool>> callback);
    }
}
