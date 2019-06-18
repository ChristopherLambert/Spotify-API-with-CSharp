using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Models;

namespace CashTeste.Helpers
{
	public static class SpotyRest
	{
		private static string _clientId = "c0dd1c6b16aa45079019930c2070cbd3";
		private static string _secretId = "62c9e4c19ed144048120c790f4235197";

		private static AuthorizationCodeAuth auth = null;
		private static SpotifyWebAPI api = null;

		public static void StartCredentialsAuth()
		{
			CredentialsAuth auth = new CredentialsAuth(_clientId, _secretId);
			Token token = auth.GetToken().Result;
			api = new SpotifyWebAPI() { TokenType = token.TokenType, AccessToken = token.AccessToken };
		}

		public static Object GetCategories(string idCategoria = null)
		{
			if (string.IsNullOrEmpty(idCategoria))
			{
				CategoryList categoryList = api.GetCategories();
				// categoryList.Categories.Items.ForEach(category => Console.WriteLine(category.Name));
				return categoryList;
			}
			else
			{
				Category category = api.GetCategory(idCategoria);
				return category;
			}
		}

		public static Paging<SimpleTrack> GetAlbunsTracks(string idAlbum = null)
		{
			Paging<SimpleTrack> tracks = api.GetAlbumTracks(idAlbum);
			// tracks.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Track-Names (max 20)
			// Console.WriteLine(tracks.Total.ToString());
			return tracks;
		}

		public static Object GetAlbuns(string idAlbum = null)
		{
			var tracks = api.GetAlbum(idAlbum);
			return tracks;
		}

		public static CategoryPlaylist GetPlaylist(string idCategoria = null, bool isPopular = false, string country = "BR")
		{
			if (!isPopular)
			{
				var playlist = api.GetCategoryPlaylists(idCategoria);
				return playlist;
			}
			else
			{
				var playlist = api.GetCategoryPlaylists(idCategoria, country, 200);
				return playlist;
			}
		}
	}
}
