﻿using System;
using System.Threading.Tasks;
using Warden.Messages.Events;
using Warden.Messages.Events.WardenChecks;

namespace Warden.Services.Stats.Handlers.Events
{
    public class WardenCheckResultProcessedHandler : IEventHandler<WardenCheckResultProcessed>
    {
        public async Task HandleAsync(WardenCheckResultProcessed @event)
        {
            Console.WriteLine("Updating stats...");
            await Task.CompletedTask;
        }
    }
}