using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Api.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class AuthActionFilter : ActionFilterAttribute
    {
        private ITokenUsuarioService _tokenUsuarioService;

        public AuthActionFilter(ITokenUsuarioService TokenUsuarioService)
            => this._tokenUsuarioService = TokenUsuarioService;

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            try
            {
                var request = actionContext.HttpContext.Request;
                var route = request.Path.HasValue ? request.Path.Value : "";
                var requestHeader = request.Headers.Aggregate("", (current, header) => current + $"{header.Key}: {header.Value}{Environment.NewLine}");

                if (requestHeader.IndexOf("Bearer") == -1)
                {
                    actionContext.Result = new JsonResult(new { erro = "Falha de validação" });
                    return;
                }

                var token = request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var claims = _tokenUsuarioService.Decodificar(token);

                if (claims.Count == 0)
                {
                    actionContext.Result = new JsonResult(new { erro = "Falha de validação", mensagem = "Token inválido" });
                    return;
                }

                if ((claims[1].Issuer != "LOCAL AUTHORITY"))
                {
                    actionContext.Result = new JsonResult(new { erro = "Falha de validação" });
                    return;
                }
            }
            catch (Exception ex)
            {
                actionContext.Result = new JsonResult(new { erro = "Falha de validação", mensagem = ex.Message });
                return;
            }
        }
    }
}