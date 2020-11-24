using System;
using System.Threading.Tasks;

namespace Exercise
{
    class Program
	{
		static async Task Main(string[] args)
		{
			var service = new Service();

			var episodeId = 3;

			var task = service.GetStarWarsEpisodeIntroduction(episodeId);

			Console.WriteLine("Waiting for film data ...");

			var film = await task;

			if (film == null)
			{
				Console.WriteLine($"Film with id {episodeId} not found!");
				return;
			}

			Console.WriteLine($"Found film with title: {film.Title}");
			Console.WriteLine($"Introduction: {film.Introduction}");
		}
	}
}
