using StackExchange.Redis;
using System.Reflection.Metadata.Ecma335;

namespace Nastenka.Services.Service
{
    public class RedisNotificationService
    {
        private ISubscriber subscriber;
        
        private List<string> messages = new List<string>();

        public RedisNotificationService()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("192.168.200.44");
            subscriber = redis.GetSubscriber();
            subscriber.Subscribe("messages", (channel, message) =>
            {
                messages.Add((string)message);
                EventHandler?.Invoke(null, null);
            });
        }

        public ISubscriber GetSub() => subscriber;

        public List<string> GetMessages() => messages;

        public EventHandler EventHandler;

        
        
    }
}
