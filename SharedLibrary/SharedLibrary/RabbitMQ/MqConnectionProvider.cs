﻿using RabbitMQ.Client;
using SharedLibrary.RabbitMQ.Interfaces;
using System;

namespace SharedLibrary.RabbitMQ
{
    public class MqConnectionProvider : IMqConnectionProvider
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;
        private bool _disposed;

        public MqConnectionProvider()
        {
            _factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672/")
            };
            _connection = _factory.CreateConnection();
        }

        public IConnection GetConnection()
        {
            return _connection;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
                _connection?.Close();

            _disposed = true;
        }
    }
}