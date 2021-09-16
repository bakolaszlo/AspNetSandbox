// <copyright file="MessageHub.cs" company="P33">
// Copyright (c) P33. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox
{
    /// <summary>Messaging class.</summary>
    public class MessageHub : Hub
    {
        /// <summary>Sends the message.</summary>
        /// <param name="user">The user.</param>
        /// <param name="message">The message.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. </returns>
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}