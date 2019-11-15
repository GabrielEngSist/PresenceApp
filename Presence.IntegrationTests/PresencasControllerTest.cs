using FluentAssertions;
using Presence.API.Contracts.V1;
using Presence.API.Contracts.V1.Requests;
using Presence.API.Domain;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Presence.IntegrationTests
{
    /// <summary>
    /// 
    /// </summary>
    public class PresencasControllerTest : IntegrationTest
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ObterTodas_SemNenhumaPresenca_RetornaRespostaVazia()
        {
            //Arrange
            await AutenticarASync();

            //Act
            var response = await _testClient.GetAsync(ApiRoutes.Presencas.ObterTodas);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<Presenca>>()).Should().BeEmpty();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Obter_QuandoPresencaExisteNaBase_RetornaPresenca()
        {
            //Arrange
            await AutenticarASync();
            var presenca = await CriarPresencaAsync(new CriarPresencaPostRequest { Observacao = "Observação para testes." });

            //Act
            var response = await _testClient.GetAsync(
                ApiRoutes.Presencas.Obter.Replace("{id}", presenca.Id.ToString()));

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var presencaEncontrada = await response.Content.ReadAsAsync<Presenca>();

            presencaEncontrada.Id.Should().Be(presenca.Id);
            presencaEncontrada.Observacao.Should().Be("Observação para testes.");
        }
    }
}
