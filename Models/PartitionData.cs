using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_AspNet_Sample_Producer.Models;

public class PartitionData
{
    [JsonProperty("partition")]
    public int Partition { get; set; }

    [JsonProperty("consumer_lag")]
    public int ConsumerLag { get; set; }
}
