using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EgBlazorComponents.Table
{
	public partial class EgCommandColumn : EgColumnBase
	{
		[Parameter] public RenderFragment ChildContent { get; set; }

		public List<EgCommandButton> CommandButtons { get; set; } = new();

		public void AddCommandButtons(EgCommandButton commandButton) => 
			CommandButtons.Add(commandButton);
	}
}
