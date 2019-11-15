using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Presence.API;
using Presence.API.Contracts.V1;
using Presence.API.Contracts.V1.Requests;
using Presence.API.Contracts.V1.Responses;
using Presence.API.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Presence.IntegrationTests
{
    public class IntegrationTest : IDisposable
    {
        protected readonly HttpClient _testClient;
        private readonly IServiceProvider _serviceProvider;

        public IntegrationTest()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(DataContext));
                        services.AddDbContext<DataContext>(options => 
                        {
                            options.UseInMemoryDatabase("Presence_test");
                        });
                    });

                });

            _serviceProvider = appFactory.Services;
            _testClient = appFactory.CreateClient();
        }

        public void Dispose()
        {
            using (var serviceScope = _serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();
                context.Database.EnsureDeleted(); 
            }
        }

        protected async Task AutenticarASync()
        {
            _testClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await ObterJwtAsync());
        }

        protected async Task<ObterPresencaResponse> CriarPresencaAsync(CriarPresencaPostRequest request)
        {
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Presencas.Criar, request);
            return await response.Content.ReadAsAsync<ObterPresencaResponse>();
        }

        private async Task<string> ObterJwtAsync()
        {
            var response = await _testClient.PostAsJsonAsync(ApiRoutes.Identity.Register, 
                new UserRegistrationRequest
                {
                    Email = "teste@teste.com.br",
                    Senha = "123@abc@ABC"
                });

            var respostaDoRegistro = await response.Content.ReadAsAsync<AuthSuccessResponse>();
            return respostaDoRegistro.Token;
        }
    }
}
