using Microsoft.AspNetCore.Components;

namespace EgBlazorComponents.Table
{
	public class EgColumnBase : EgComponentBase
	{
		#region Properties

		[Parameter] public string Title { get; set; }
		[CascadingParameter] public EgTable Table { get; set; }

		#endregion Properties

		#region Override Methods

		protected override void OnInitialized()
		{
			base.OnInitialized();
			Table.AddColumn(this);
		}

		#endregion Override Methods
	}
}
