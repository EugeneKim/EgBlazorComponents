using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace EgBlazorComponents.Table
{
	public partial class EgSearch : EgComponentBase
	{
		#region Properties

		[CascadingParameter] public EgTable Table { get; set; }
		[Parameter] public EventCallback<int> OnSearch { get; set; }

		#endregion Properties

		#region Fields

		private string searchValue;

		#endregion Fields

		#region Private Methods

		private async Task OnSearchButtonClickAsync() => await Search();

		private async Task OnKeyUpAsync(KeyboardEventArgs e)
		{
			if (e.Key == "Enter")
				await Search();
		}

		private async Task OnClearButtonClickAsync()
		{
			searchValue = string.Empty;
			await Search();
		}

		private async Task Search() => await Table.SearchAsync(searchValue);

		#endregion Private Methods
	}
}
