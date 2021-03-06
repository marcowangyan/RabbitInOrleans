﻿using System;
using System.Threading.Tasks;
using global::Orleans;
using global::Orleans.Providers;

namespace Logging.Orleans
{
    public class OrleansLoggerProvider : IBootstrapProvider
    {
        public OrleansLoggerProvider(string name)
        {
            Name = name;
        }

        public OrleansLoggerProvider()
        { }

        public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
        {
            var logger = providerRuntime.GetLogger("OrleansLog");

            OrleansLoggerSingleton.WithLogger(logger);

            return TaskDone.Done;
        }

        public Task Close()
        {
            return TaskDone.Done;
        }

        public string Name { get; private set; }
    }
}
