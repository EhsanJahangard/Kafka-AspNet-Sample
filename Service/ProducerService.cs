using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Kafka_AspNet_Sample_Producer.Configurations;
using Microsoft.Extensions.Options;
using LZ4;
using Microsoft.Extensions.Logging;
using Kafka_AspNet_Sample_Producer.Models;
using Microsoft.Extensions.Hosting;
namespace Kafka_AspNet_Sample_Producer.Service;

public class ProducerService : IHostedService, IDisposable
{
    private IProducer<string, string> _producer;
    private readonly KafkaConfiguration _kafkaConfiguration;
    //private readonly ILogger<ProducerService> _logger;

    //public ProducerService( IOptions<KafkaConfiguration> kafkaConfigurationOptions)
    public ProducerService()
    {
        
        //_kafkaConfiguration = kafkaConfigurationOptions?.Value ?? throw new ArgumentException(nameof(kafkaConfigurationOptions));

        Init();
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                //_logger.LogInformation("Kafka Producer Service has started.");
                Console.WriteLine("Kafka Producer Service has started.");
                await Produce(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Kafka Error");
                //_logger.LogError(ex, ex.Message);
            }
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        //_logger.LogInformation("Kafka Producer Service is stopping.");

        _producer.Flush(cancellationToken);

        await Task.CompletedTask;
    }

    public void Dispose()
    {
        _producer.Dispose();
    }

    private void Init()
    {
        //var pemFileWithKey = "./keystore/secure.pem";

        var config = new ProducerConfig()
        {
            BootstrapServers = "192.168.21.85:9092",// _kafkaConfiguration.Brokers,
            ClientId = "Kafka.Dotnet.Sample",

            //SslCaLocation = pemFileWithKey,
            //SslCertificateLocation = pemFileWithKey,
            //SslKeyLocation = pemFileWithKey,

            //Debug = "broker,topic,msg",

            SecurityProtocol = SecurityProtocol.Plaintext,
            EnableDeliveryReports = false,
            QueueBufferingMaxMessages = 10000000,
            QueueBufferingMaxKbytes = 100000000,
            BatchNumMessages = 500,
            Acks = Acks.None,
            DeliveryReportFields = "none"
        };

        _producer = new ProducerBuilder<string, string>(config).Build();
    }
    
    private async Task Produce(CancellationToken cancellationToken)
    {
        try
        {
            
                if (!cancellationToken.IsCancellationRequested)
                {
                    for (int i = 0; i < 1001; i++)
                    {
                        var json = new SampleData().ToString();

                        var msg = new Message<string, string>
                        {
                            Key = "sample_key",
                            Value = Convert.ToBase64String(LZ4Codec.Wrap(Encoding.UTF8.GetBytes(json)))
                        };
                        await _producer.ProduceAsync("sample_topic", msg, cancellationToken).ConfigureAwait(false);
                    }
                }
            
        }
        catch (Exception exception)
        {
            
        }
    }

}
