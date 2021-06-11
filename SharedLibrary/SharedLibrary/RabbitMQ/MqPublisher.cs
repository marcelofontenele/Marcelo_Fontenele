using RabbitMQ.Client;
using SharedLibrary.RabbitMQ.Interfaces;
using System;
using System.Text;
using System.Text.Json;

namespace SharedLibrary.RabbitMQ
{
    public class MqPublisher : IMqPublisher
    {
        private readonly IMqConnectionProvider _connectionProvider;
        private readonly string _exchange;
        private readonly IModel _channel;
        private bool _disposed;

        public MqPublisher(IMqConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
            _channel = _connectionProvider.GetConnection().CreateModel();
        }

        public void Publish(string exchange, object message)
        {
            try
            {
                _channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);

                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                _channel.BasicPublish(exchange: exchange,
                                         routingKey: "",
                                         basicProperties: null,
                                         body: body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _channel?.Close();

            _disposed = true;
        }
    }
}