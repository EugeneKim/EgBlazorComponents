using EgBlazorComponents.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgBlazorComponents.Demo.Services
{
	/// <summary>
	/// Service consumed by a client for the <see cref="WordModel"/> objects.
	/// </summary>
	public class WordsCollectionService
	{
		private readonly IList<WordModel> words;

		public WordsCollectionService()
		{
			// License to https://github.com/wpatoolkit/Adj-Noun-Wordlist-Generator

			var adjectives = new[] { "ancient", "antique", "aquatic", "baby", "basic", "big", "bitter", "black", "blue", "bottle", "bottled", "brave", "breezy", "bright", "brown", "calm", "charming", "cheerful", "chummy", "classy", "clear", "clever", "cloudy", "cold", "cool", "crispy", "curly", "daily", "deep", "delightful", "dizzy", "down", "dynamic", "elated", "elegant", "excited", "exotic", "fancy", "fast", "fearless", "festive", "fluffy", "fragile", "fresh", "friendly", "funny", "fuzzy", "gentle", "gifted", "gigantic", "graceful", "grand", "grateful", "great", "green", "happy", "heavy", "helpful", "hot", "hungry", "husky", "icy", "imaginary", "invisible", "jagged", "jolly", "joyful", "joyous", "kind", "large", "light", "little", "lively", "lovely", "lucky", "lumpy", "magical", "manic", "melodic", "mighty", "misty", "modern", "narrow", "new", "nifty", "noisy", "normal", "odd", "old", "orange", "ordinary", "painless", "pastel", "peaceful", "perfect", "phobic", "pink", "polite", "precious", "pretty", "purple", "quaint", "quick", "quiet", "rapid", "red", "rocky", "rough", "round", "royal", "rugged", "rustic", "safe", "sandy", "shiny", "silent", "silky", "silly", "slender", "slow", "small", "smiling", "smooth", "snug", "soft", "sour", "strange", "strong", "sunny", "sweet", "swift", "thirsty", "thoughtful", "tiny", "uneven", "unusual", "vanilla", "vast", "violet", "warm", "watery", "weak", "white", "wide", "wild", "wilde", "windy", "wise", "witty", "wonderful", "yellow", "young", "zany" };
			var nouns = new[] { "airplane", "apple", "automobile", "ball", "balloon", "banana", "beach", "bird", "boat", "boot", "bottle", "box", "breeze", "bug", "bush", "butter", "canoe", "carrot", "cartoon", "cello", "chair", "cheese", "coast", "coconut", "comet", "cream", "curtain", "daisy", "desk", "diamond", "door", "earth", "elephant", "emerald", "fire", "flamingo", "flower", "flute", "forest", "free", "giant", "giraffe", "glove", "grape", "grasshopper", "hair", "hat", "hill", "house", "ink", "iris", "jade", "jungle", "kangaroo", "kayak", "lake", "lemon", "lightning", "lion", "lotus", "lump", "mango", "mint", "monkey", "moon", "motorcycle", "mountain", "nest", "oboe", "ocean", "octopus", "onion", "orange", "orchestra", "owl", "path", "penguin", "phoenix", "piano", "pineapple", "planet", "pond", "potato", "prairie", "quail", "rabbit", "raccoon", "raid", "rain", "raven", "river", "road", "rosebud", "ruby", "sea", "ship", "shoe", "shore", "shrub", "sitter", "skates", "sky", "socks", "sparrow", "spider", "squash", "squirrel", "star", "stream", "street", "sun", "table", "teapot", "terrain", "tiger", "toast", "tomato", "trail", "train", "tree", "truck", "trumpet", "tuba", "tulip", "umbrella", "unicorn", "unit", "valley", "vase", "violet", "violin", "water", "wind", "window", "zebra", "zoo" };

			var random = new Random();

			Shuffle(adjectives, random);
			Shuffle(nouns, random);

			// Seed data.

			var numOfAdjectives = adjectives.Length;
			var numOfNouns = nouns.Length;

			var numOfItems = 210;
			var i = 0;

			words = new List<WordModel>(numOfItems);

			for (var l1 = 0; l1 < numOfAdjectives; l1++)
			{
				for (var l2 = 0; l2 < numOfNouns; l2++)
				{
					words.Add(new WordModel(random.Next(0, 2) == 0 ? Priority.High : Priority.Low, $"{adjectives[l1]} {nouns[l2]}"));

					if (++i == numOfItems)
						return;
				}
			}
		}

		public async Task<(int Total, IReadOnlyList<WordModel> Words)> GetWordsAsync(int current, int size, string filter = null) =>
			(
				await Task.FromResult(GetFilteredWords(filter).Count()),
				await Task.FromResult(GetFilteredWords(filter).Skip((current - 1) * size).Take(size).ToList())
			);

		public async Task DeleteWordAsync(WordModel word)
		{
			var found = words.Where(w => w.Equals(word)).ToList();

			if (found.Count == 1 && words.Remove(found.First()))
				await Task.CompletedTask;
			else
				await Task.FromException(new ArgumentException($"Failed to delete the word: {word}"));
		}

		private IEnumerable<WordModel> GetFilteredWords(string filter) =>
			string.IsNullOrEmpty(filter) 
				? words
				: words.Where(w => w.Word.Contains(filter, StringComparison.OrdinalIgnoreCase));

		private static void Shuffle(IList<string> array, Random random)
		{
			var length = array.Count;

			for (var i = 0; i < length-1; i++)
			{
				var index = i + random.Next(length-i);
				(array[index], array[i]) = (array[i], array[index]);
			}
		}
	}
}
