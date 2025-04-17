using Newtonsoft.Json;

namespace Kafka_AspNet_Sample_Producer.Models;

public class SampleData
{
    public Guid Id { get; set; }
    public double Value { get; set; }
    public DateTime Created { get; set; }

    public SampleData()
    {
        Id = Guid.NewGuid();
        Value = new Random().Next(999,900000);
        Created = DateTime.UtcNow;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
    }
}