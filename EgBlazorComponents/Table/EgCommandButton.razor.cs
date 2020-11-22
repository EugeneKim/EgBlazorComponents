using EgBlazorComponents.Args;
using Microsoft.AspNetCore.Components;

namespace EgBlazorComponents.Table
{
	public class EgCommandButton : EgComponentBase
	{
		[CascadingParameter] public EgCommandColumn CommandColumn { get; set; }

		[Parameter] public string Caption { get; set; }

		[Parameter] public EventCallback<TableCommandButtonArgs> OnClick { get; set; }

		public bool Disabled => !OnClick.HasDelegate;

		protected override void OnInitialized() =>
			CommandColumn.AddCommandButtons(this);
	}
}
