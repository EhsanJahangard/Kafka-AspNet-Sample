using Confluent.Kafka;
using Kafka_AspNet_Sample_Producer.Service;


Console.WriteLine("Producer is running...");
ProducerService producer = new ProducerService();
// Define the cancellation token.
CancellationTokenSource source = new CancellationTokenSource();
CancellationToken token = source.Token;
await producer.StartAsync(token);





