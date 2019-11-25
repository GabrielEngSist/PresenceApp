using Presence.API.Contracts.V1.Responses.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presence.API.Utils
{
    public static class Helper
    {
        public static IdNomeDto ConverterParaIdNomeDto<T>(this T obj, string nome) 
        {
            var tipo = obj.GetType();
            var id = tipo.GetProperty("Id");
            var nomeProp = tipo.GetProperty(nome);

            nome = nomeProp == null 
                ? nome
                : nomeProp.GetValue(obj).ToString();

            return new IdNomeDto 
            {
                Id = Guid.Parse(id.GetValue(obj).ToString()),
                Nome = nome
            };
        }
    }
}
