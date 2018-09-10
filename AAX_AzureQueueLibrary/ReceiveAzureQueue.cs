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
    public class ReceiveAzureQueue
    {
        QueueClient queueClient;
        BrokeredMessage message;

        public void connect(string connectionString)
        {
            queueClient = QueueClient.CreateFromConnectionString(connectionString, ReceiveMode.PeekLock);
        }

        public string readMessage()
        {
            message = queueClient.Receive();

            string s = message.GetBody<String>();

            return (s);
        }

        public void completeMessage()
        {
            queueClient.Complete(message.LockToken);
        }

        public void close()
        {
            queueClient.Close();
        }
    }

    
}
