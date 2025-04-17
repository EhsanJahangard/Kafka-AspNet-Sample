using Newtonsoft.Json;

namespace Kafka_AspNet_Sample_Producer.Models;

public class TopicData
{
    [JsonProperty("topic")]
    public string Topic { get; set; }

    [JsonProperty("partitions")]
    public IReadOnlyDictionary<string, PartitionData> Partitions { get; set; }
}