using RabbitMQ.Client;
using System;

namespace SharedLibrary.RabbitMQ.Interfaces
{
    public interface IMqConnectionProvider : IDisposable
    {
        IConnection GetConnection();
    }
}