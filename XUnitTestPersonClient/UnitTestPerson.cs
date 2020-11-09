using AutoFixture;
using ConsoleAppConsumeApi.Model;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using Newtonsoft.Json;
using System.Text;
using ConsoleAppConsumeApi.Core;
using FluentAssertions;
using Moq;
using Moq.Protected;
using System.Threading;

namespace XUnitTestPersonClient
{
    public class UnitTestPerson
    {
        [Fact]
        public async Task GetPerson()
        {
            // Arrange
            var person = new ReadOnlyPerson
            {
                Person = new Person() { Id = 1 },
                DetailPerson = new DetailPerson
                {
                    Name = "aaaa",
                    Email = "xxxxx@xxxxx.com",
                    Telefono = "xxxxxxx"
                }
            };
            var fixture = new Fixture();
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();



            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(person), Encoding.UTF8, "application/json")
               })
               .Verifiable();


            var fakeHttpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = fixture.Create<Uri>()
            };
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(fakeHttpClient);
            var apiRestHelper = new HttpWrapperClient(httpClientFactoryMock.Object, "PersonApiClient");

            //httpClientFactoryMock.CreateClient().Returns(fakeHttpClient);

            // Act
            var service = new PersonApiClient(apiRestHelper);
            var result = await service.GetPersonAsync(1);

            // Assert
            result.Should()
            .BeOfType<ReadOnlyPerson>().Which.DetailPerson.Name.Should().Be("aaaa");
            Assert.NotNull(result);
            //Assert.IsAssignableFrom<OkObjectResult>(result);
        }




        [Fact]
        public async Task POST()
        {
            // Arrange
            var newPerson = new AddPerson
            {
                Campaign = new Campaign { Id = 1 },
                DetailPerson = new DetailPerson()
                {
                    Name = "Test",
                    Email = "xxxxx@xxxxxx.com",
                    Telefono = "xxxxxxxx",

                }
            };


            //string newPerson = "{ \"Campaign\":{ \"campaignId\":1},\"DetailPerson\":{ \"Name\":\"Test\",\"Email\":\"xxxxx @xxxxxx.com\",\"Telefono\":\"xxxxxxxx\",\"Date\":\"2020 -11-08T22:02:51.3028904+01:00\"} }";

            var fixture = new Fixture();
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();

            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
               .Protected()
               // Setup the PROTECTED method to mock
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>()
               )
               // prepare the expected response of the mocked http call
               .ReturnsAsync(new HttpResponseMessage()
               {
                   StatusCode = HttpStatusCode.OK,
                   Content = new StringContent(JsonConvert.SerializeObject(fixture.Create<string>()), Encoding.UTF8, "application/json")
               })
               .Verifiable();


            var fakeHttpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = fixture.Create<Uri>()
            };
            httpClientFactoryMock.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(fakeHttpClient);
            var apiRestHelper = new HttpWrapperClient(httpClientFactoryMock.Object, "PersonApiClient");

            // Act
            var service = new PersonApiClient(apiRestHelper);
            var result = await service.PostPersonAsync(newPerson);

            // Assert
            Assert.NotNull(result);
        }
    }

}
