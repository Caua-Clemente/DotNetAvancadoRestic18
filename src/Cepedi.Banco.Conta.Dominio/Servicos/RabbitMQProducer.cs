using RabbitMQ.Client;
using System;
using System.Text;

namespace Cepedi.Banco.Conta.Dominio.Servicos;
public static class RabbitMQProducer 
{
    /*
        Essa parte do código em si "aparenta" estar correta,
        porém o projeto em si não está funcionando por algum motivo 
        (testei no projeto de cleanArch também e não funcionou o projeto puro)

        Não deixei o Service na camada de api pois precisava executar ele num handler.
        Talvez o melhor seria colocar na camada de shareable (ou melhor ainda, na camada
        de RabbitMQ, como foi mostrado no final da aula), mas ainda assim 
        o projeto não está funcionando, então não estou conseguindo executar os
        devidos testes
    */

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
