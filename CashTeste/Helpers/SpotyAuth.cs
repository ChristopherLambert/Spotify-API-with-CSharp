using System;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace CashTeste.Helpers
{
	public class SpotyAuth
	{
		private static string _clientId = "c0dd1c6b16aa45079019930c2070cbd3";
		private static string _secretId = "62c9e4c19ed144048120c790f4235197";

		private static AuthorizationCodeAuth auth = null;
		private static SpotifyWebAPI api = null;

		public static void Start()
		{
			_clientId = string.IsNullOrEmpty(_clientId)
				? Environment.GetEnvironmentVariable("SPOTIFY_CLIENT_ID")
				: _clientId;

			_secretId = string.IsNullOrEmpty(_secretId)
				? Environment.GetEnvironmentVariable("SPOTIFY_SECRET_ID")
				: _secretId;

			Console.WriteLine("####### Spotify API Example #######");
			Console.WriteLine("This example uses AuthorizationCodeAuth.");
			Console.WriteLine(
				"Tip: If you want to supply your ClientID and SecretId beforehand, use env variables (SPOTIFY_CLIENT_ID and SPOTIFY_SECRET_ID)");

			AuthorizationCodeAuth auth =
				new AuthorizationCodeAuth(_clientId, _secretId, "http://localhost:4002", "http://localhost:4002",
					Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative);
			auth.AuthReceived += AuthOnAuthReceived;
			auth.Start();
			auth.OpenBrowser();

			Console.ReadLine();
			auth.Stop(0);
		}

		public static async void AuthOnAuthReceived(object sender, AuthorizationCode payload)
		{
			AuthorizationCodeAuth auth = (AuthorizationCodeAuth)sender;
			auth.Stop();

			Token token = await auth.ExchangeCode(payload.Code);
			api = new SpotifyWebAPI
			{
				AccessToken = token.AccessToken,
				TokenType = token.TokenType
			};
			PrintUsefulData();
		}

		public static async void PrintUsefulData()
		{
			PrivateProfile profile = await api.GetPrivateProfileAsync();
			string name = string.IsNullOrEmpty(profile.DisplayName) ? profile.Id : profile.DisplayName;
			Console.WriteLine($"Hello there, {name}!");

			Console.WriteLine("Your playlists:");
			Paging<SimplePlaylist> playlists = await api.GetUserPlaylistsAsync(profile.Id);
			do
			{
				playlists.Items.ForEach(playlist =>
				{
					Console.WriteLine($"- {playlist.Name}");
				});
				playlists = await api.GetNextPageAsync(playlists);
			} while (playlists.HasNextPage());
		}
	}
}
