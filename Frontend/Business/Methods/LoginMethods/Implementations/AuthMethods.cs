using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Methods.LoginMethods.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;


namespace Business.Methods.LoginMethods.Implementations
{
	public class AuthMethods : IAuthMethods
	{
		AuthenticationStateProvider _authenticationStateProvider;
		NavigationManager _navigationManager;

		public AuthMethods(AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
		{
			_authenticationStateProvider = authenticationStateProvider;
			_navigationManager = navigationManager;
		}
		public async Task CheckAuthBeforeRequests()
		{
			var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
			var user = authState.User;
			if (!user.Identity.IsAuthenticated)
			{
				_navigationManager.NavigateTo("/login");
				return;
			}
		}


		public async Task<string> GetClaim(string claimType)
		{

			var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
			var user = authState.User;

			var claim=user.Claims.FirstOrDefault(c => c.Type == claimType);
			return claim!.Value.ToString();
		}
	}
}
