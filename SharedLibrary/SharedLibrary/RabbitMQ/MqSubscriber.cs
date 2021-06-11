using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SharedLibrary.RabbitMQ.Interfaces;
using System;
using System.Text;

namespace SharedLibrary.RabbitMQ
{
    public class MqSubscriber : IMqSubscriber
    {
        private readonly IMqConnectionProvider _connectionProvider;
        private readonly IModel _channel;
        private bool _disposed;

        public MqSubscriber(
            IMqConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
            _channel = _connectionProvider.GetConnection().CreateModel();
        }

        public void Subscribe(string exchange, Action<string> callback)
        {
            try
            {
                _channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);

                var queueName = _channel.QueueDeclare().QueueName;

                _channel.QueueBind(queue: queueName,
                                      exchange: exchange,
                                      routingKey: "");

                var consumer = new EventingBasicConsumer(_channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    callback.Invoke(message);
                };

                _channel.BasicConsume(queue: queueName,
                                         autoAck: true,
                                         consumer: consumer);
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