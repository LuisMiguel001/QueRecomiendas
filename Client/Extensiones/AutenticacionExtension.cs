﻿using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using QueRecomiendas.Shared.Login;
using System.Security.Claims;

namespace QueRecomiendas.Client.Extensiones
{
	public class AutenticacionExtension : AuthenticationStateProvider
	{
		private readonly ISessionStorageService _sessionStorage;
		private ClaimsPrincipal _sinInformacion = new ClaimsPrincipal(new ClaimsIdentity());

		public AutenticacionExtension(ISessionStorageService sessionStorage)
		{
			_sessionStorage = sessionStorage;
		}

		public async Task ActualizarEstadoAutenticacion(Sesion? sesionUsuario)
		{
			ClaimsPrincipal claimsPrincipal;

			if (sesionUsuario != null)
			{
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, sesionUsuario.Nombre ?? ""),
					new Claim(ClaimTypes.Email, sesionUsuario.Correo ?? ""),
					new Claim(ClaimTypes.Role, sesionUsuario.Rol ?? "")
				};

				claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuth"));

				await _sessionStorage.GuardarStorage("sesionUsuario", sesionUsuario);
			}
			else
			{
				claimsPrincipal = _sinInformacion;
				await _sessionStorage.RemoveItemAsync("sesionUsuario");
			}

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
		}



		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{

			var sesionUsuario = await _sessionStorage.ObtenerStorage<Sesion>("sesionUsuario");

			if (sesionUsuario == null)
			{
				return await Task.FromResult(new AuthenticationState(_sinInformacion));
			}

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, sesionUsuario.Nombre ?? ""),
				new Claim(ClaimTypes.Email, sesionUsuario.Correo ?? ""),
				new Claim(ClaimTypes.Role, sesionUsuario.Rol ?? "")
			};

			var claimPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "JwtAuth"));

			return await Task.FromResult(new AuthenticationState(claimPrincipal));
		}
	}
}
