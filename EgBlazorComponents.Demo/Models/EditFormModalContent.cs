using System;
using System.ComponentModel.DataAnnotations;

namespace EgBlazorComponents.Demo.Models
{
	public class EditFormModalContent
	{
		[Required]
		[StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
		public string Identifier { get; set; }

		public string Description { get; set; }

		[Required]
		public string Classification { get; set; }

		[Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
		public int MaximumAccommodation { get; set; }

		[Required]
		[Range(typeof(bool), "true", "true", ErrorMessage = "This form disallows unapproved ships.")]
		public bool IsValidatedDesign { get; set; }

		[Required]
		public DateTime ProductionDate { get; set; }

		public void Update(EditFormModalContent their)
		{
			Identifier = their.Identifier;
			Description = their.Description;
			Classification = their.Classification;
			MaximumAccommodation = their.MaximumAccommodation;
			IsValidatedDesign = their.IsValidatedDesign;
			ProductionDate = their.ProductionDate;
		}
	}
}
