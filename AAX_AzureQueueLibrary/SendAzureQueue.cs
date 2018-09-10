using Microsoft.ServiceBus.Messaging;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

namespace AAX_AzureQueueLibrary
{
    public class SendAzureQueue
    {
        QueueClient queueClient;
        BrokeredMessage message;

        public void connect(string connectionString)
        {
            queueClient = QueueClient.CreateFromConnectionString(connectionString, ReceiveMode.PeekLock);
        }

        public void sendMessage(string s)
        {
            message = new BrokeredMessage(s);
            queueClient.Send(message);
        }

        public void close()
        {
            queueClient.Close();
        }
    }
}
