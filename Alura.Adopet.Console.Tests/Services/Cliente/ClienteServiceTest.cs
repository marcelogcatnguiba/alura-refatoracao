using System.Net;
using Alura.Adopet.Console.Services;
using Alura.Adopet.Console.Services.Clientes;
using FluentAssertions;
using Moq;
using Moq.Protected;

namespace Alura.Adopet.Console.Tests.Services.Cliente
{
    public class ClienteServiceTest
    {
        [Fact]
        public async void DeveRetornarListaDeClientes()
        {
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent
                (
                    """
                    [
                        {
                            "Id" : "456b24f4-19e2-4423-845d-4a80e8854a41",
                            "Nome" : "Fulnao de Tal",
                            "Email" : "fulano@example.org"
                        },
                        {
                            "Id" : "3aeff89d-7da2-4603-852e-d232fbdc56bd",
                            "Nome" : "Jose Silva",
                            "Email" : "silva@example.org"
                        },
                        {
                            "Id" : "609c9b0d-aa02-459f-a340-256513fc9bad",
                            "Nome" : "Rogerio Milano",
                            "Email" : "milano@example.org"
                        }
                    ]
                    """
                )
            };

            var messageHandlerMock = new Mock<HttpMessageHandler>();
            messageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
            
            HttpClient client = new (messageHandlerMock.Object)
            {
                BaseAddress = new Uri(@"http://localhost:5057")
            };
            
            ClienteService service = new(client);

            var result = await service.ListAsync();

            result.Should().HaveCount(3);
        }
    }
}