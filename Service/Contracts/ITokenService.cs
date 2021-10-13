using System;
using System.Collections.Generic;
using System.Security.Claims;
using Domain.Entity;

public interface ITokenUsuarioService
{
    List<Claim> Decodificar(string token);

    string Gerar(Usuario usuario, DateTime? expiracao = null);
}