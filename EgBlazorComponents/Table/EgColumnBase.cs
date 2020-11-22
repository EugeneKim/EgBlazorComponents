using Microsoft.AspNetCore.Components;

namespace EgBlazorComponents.Table
{
	public class EgColumnBase : EgComponentBase
	{
		[Parameter]
		public string Title { get; set; }

		[CascadingParameter]
		public EgTable Table { get; set; }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Table.AddColumn(this);
		}
	}
}
