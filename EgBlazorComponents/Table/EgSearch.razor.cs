using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace EgBlazorComponents.Table
{
	public partial class EgSearch : EgComponentBase
	{
		private string SearchValue { get; set; }

		[CascadingParameter]
		public EgTable Table { get; set; }

		[Parameter]
		public EventCallback<int> OnSearch { get; set; }

		private async Task OnSearchButtonClickAsync() =>
			await Search();

		private async Task OnKeyUpAsync(KeyboardEventArgs e)
		{
			if (e.Key == "Enter")
				await Search();
		}

		private async Task OnClearButtonClickAsync()
		{
			SearchValue = string.Empty;
			await Search();
		}

		private async Task Search() =>
			await Table.SearchAsync(SearchValue);
	}
}
