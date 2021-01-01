using EgBlazorComponents.Args;
using Microsoft.AspNetCore.Components;

namespace EgBlazorComponents.Table
{
	public class EgCommandButton : EgComponentBase
	{
		#region Properties

		[CascadingParameter] public EgCommandColumn CommandColumn { get; set; }
		[Parameter] public string Caption { get; set; }
		[Parameter] public EventCallback<TableCommandButtonArgs> OnClick { get; set; }

		public bool Disabled => !OnClick.HasDelegate;

		#endregion Properties

		#region Override Methods

		protected override void OnInitialized() => CommandColumn.AddCommandButtons(this);

		#endregion Override Methods
	}
}
