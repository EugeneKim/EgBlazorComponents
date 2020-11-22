using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace EgBlazorComponents.Table
{
	public partial class EgSearch : EgComponentBase
	{
		[CascadingParameter]
		public EgTable Table { get; set; }

		[Parameter]
		public EventCallback<int> OnSearch { get; set; }

		private string searchValue;

		private async Task OnSearchButtonClickAsync() =>
			await Search();

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

		private async Task Search() =>
			await Table.SearchAsync(searchValue);
	}
}
