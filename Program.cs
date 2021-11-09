using System;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AloArtigoTech
{
    class Program
    {
        static void Main(string[] args)
        {
            string accountSid = Environment.GetEnvironmentVariable("SEU TWILIO_ACCOUNT_SID, PEGUE NA SUA CONTA DO TWILIO");
            string authToken = Environment.GetEnvironmentVariable("SEU TWILIO_AUTH_TOKEN, PEGUE NA SUA CONTA DO TWILIO");

            string callNumberTo = Environment.GetEnvironmentVariable("COLOQUE AQUI O NÚMERO QUE RECEBERÁ A LIGAÇÃO");
            string callNumberFromTwilio = Environment.GetEnvironmentVariable("NÚMERO GERADO PELO TWILIO, PEGUE NA SUA CONTA DO TWILIO");

            TwilioClient.Init(accountSid, authToken);

            StringBuilder mensagem = new StringBuilder();

            mensagem.AppendLine("<Response>");
                mensagem.AppendLine("<Say language='pt-BR'>");
                    mensagem.AppendLine("Aqui é o Canal Artigo Tech, se você quer saber sobre Tecnologia, Programação e Carreira Tech");
                    mensagem.AppendLine("você está no lugar certo! Por isso não deixe de ser inscrever no canal e ativar o sininho");
                    mensagem.AppendLine("para receber as notificações dos próximos vídeos! Obrigado, grande abraço e fica com Deus!");
                mensagem.AppendLine("</Say>"); 
            mensagem.AppendLine("</Response>");

            var call = CallResource.Create(
                to: new Twilio.Types.PhoneNumber(callNumberTo),
                from: new Twilio.Types.PhoneNumber(callNumberFromTwilio),
                twiml: mensagem.ToString()
            );

            Console.WriteLine(call.Sid);
        }
    }
}
