using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafka_AspNet_Sample_Producer.Models;

public class KafkaStatistics
{
    /// <summary>
    ///     Handle instance name.
    /// </summary>
    [JsonProperty("name")]
    public string name { get; set; }

    [JsonProperty("topics")]
    public IReadOnlyDictionary<string, TopicData> topics { get; set; }

}
