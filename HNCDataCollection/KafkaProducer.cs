using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using System.Collections.Generic;
using System.Text;

namespace HNCDataCollection
{
    class KafkaProducer
    {
        private Dictionary<string, object> config;
        private string topic;

        public KafkaProducer(string kafkaIpWithPort, string topic)
        {
            this.topic = topic;

            config = new Dictionary<string, object>
            {
                ["bootstrap.servers"] = kafkaIpWithPort,
                ["retries"] = 0,
                ["batch.num.messages"] = 1,
                ["socket.blocking.max.ms"] = 1,
                ["socket.nagle.disable"] = true,
                ["queue.buffering.max.ms"] = 0,
                ["default.topic.config"] = new Dictionary<string, object>
                {
                    ["acks"] = 1
                }
            };
        }
        
        public string ProduceToKafka(string msg)
        {
            using (var producer = new Producer<Null, string>(config, null, new StringSerializer(Encoding.UTF8)))
            {
                var dr = producer.ProduceAsync(topic, null, msg).Result;
                return dr.TopicPartitionOffset.ToString();
            }
        }
    }
}
