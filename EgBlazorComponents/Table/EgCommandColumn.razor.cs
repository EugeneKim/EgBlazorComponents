using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace EgBlazorComponents.Table
{
	public partial class EgCommandColumn : EgColumnBase
	{
		#region Properties

		[Parameter] public RenderFragment ChildContent { get; set; }

		public List<EgCommandButton> CommandButtons { get; set; } = new();

		#endregion Properties

		#region Public Methods

		public void AddCommandButtons(EgCommandButton commandButton) =>  CommandButtons.Add(commandButton);

		#endregion Public Methods
	}
}
