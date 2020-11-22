using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents.Pagination
{
	public partial class EgPagination : EgComponentBase
	{
		[Parameter] public int TotalPages { get; set; }

		[Parameter] public int CurrentPage { get; set; }

		[Parameter] public int PaginationSize { get; set; } = 10;

		[Parameter] public EventCallback<int> OnClick { get; set; }

		private int currentPaginationIndex;

		private bool isPreviousButtonEnabled;

		private bool isNextButtonEnabled;

		private int startPage;

		private int numOfPages;

		protected override void OnParametersSet()
		{
			currentPaginationIndex = (CurrentPage - 1) / PaginationSize;

			isPreviousButtonEnabled = currentPaginationIndex < 1;
			isNextButtonEnabled = GetStartPage(currentPaginationIndex + 1) > TotalPages;

			startPage = GetStartPage(currentPaginationIndex);
			numOfPages = Math.Min(PaginationSize, TotalPages - startPage + 1);
		}

		private async Task OnPageButtonClickAsync(int page)
		{
			if (OnClick.HasDelegate)
				await OnClick.InvokeAsync(page);
		}

		private int GetStartPage(int paginationIndex) =>
			PaginationSize * paginationIndex + 1;
	}
}
