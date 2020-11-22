using System;

namespace EgBlazorComponents.Demo.Models
{
	public class WordModel : IEquatable<WordModel>
	{
		public string Priority { get; }
		public string Word { get; }

		public WordModel(string priority, string word) => (Priority, Word) = (priority, word);

		public override string ToString() => $"Priority: {Priority}, Word = {Word}";

		public bool Equals(WordModel other) =>
			other != null && Priority == other.Priority && Word == other.Word;

		public override bool Equals(object obj) =>
			ReferenceEquals(this, obj) || obj is WordModel other && Equals(other);

		public override int GetHashCode() =>
			Priority.GetHashCode() + Word.GetHashCode();
	}
}
