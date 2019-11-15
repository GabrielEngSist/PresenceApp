using Microsoft.AspNetCore.Http;
using Presence.API.Options.DatabaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Presence.API.Extensions
{

    public static class GeneralExtensions
    {


        public static Guid ObterIdUsuario(this HttpContext httpContext) =>
           httpContext.User == null 
            ? Guid.Empty 
            : Guid.Parse(httpContext.User.Claims.Single(u => u.Type == "id").Value);


        public static string SepararCamelCase(this string texto)
        => Regex.Replace(Regex.Replace(texto, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
                
        public static T ObterValorEnum<T>(this string value) => (T)Enum.Parse(typeof(T), value, true);
    }
}
