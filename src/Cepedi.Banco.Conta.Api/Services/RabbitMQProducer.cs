using RabbitMQ.Client;
using System;
using System.Text;

namespace Cepedi.Banco.Conta.Api.Services;
public static class RabbitMQProducerOld 
{
    public static void EnviarMensagem(){
        var factory = new ConnectionFactory(){ 
                                                Port = 5672,
                                                HostName = "srv508250.hstgr.cloud", 
                                                //Queue = "Fila.Teste", 
                                                UserName = "aluno",
                                                Password = "changeme"
                                             };

        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "Fila.Teste",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            
            string message = "10^28 yotabytes";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message);                    
        }

        Console.WriteLine(" Press [enter] to exit.");
        Console.ReadLine();
    }
}
