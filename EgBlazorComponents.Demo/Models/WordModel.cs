using System;

namespace EgBlazorComponents.Demo.Models
{
	public class WordModel : IEquatable<WordModel>
	{
		public Priority Priority { get; set; }
		public string Word { get; set; }

		public WordModel(Priority priority, string word) => (Priority, Word) = (priority, word);

		public override string ToString() => $"Priority: {Priority}, Word = {Word}";

		public bool Equals(WordModel other) =>
			other != null && Priority == other.Priority && Word == other.Word;

		public override bool Equals(object obj) =>
			ReferenceEquals(this, obj) || obj is WordModel other && Equals(other);

		public override int GetHashCode() =>
			Priority.GetHashCode() + Word.GetHashCode();
	}
}
