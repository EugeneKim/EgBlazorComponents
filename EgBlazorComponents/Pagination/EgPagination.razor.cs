using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents.Pagination
{
	public partial class EgPagination : EgComponentBase
	{
		#region Parameter Properties

		[Parameter]
		public int TotalPages { get; set; }

		[Parameter]
		public int CurrentPage { get; set; }

		[Parameter]
		public int PaginationSize { get; set; } = 10;

		[Parameter]
		public EventCallback<int> OnClick { get; set; }

		#endregion Parameter Properties

		private int CurrentPaginationIndex { get; set; }

		private bool IsPreviousButtonEnabled { get; set; }

		private bool IsNextButtonEnabled { get; set; }
		private int StartPage { get; set; }

		private int EndPage { get; set; }

		protected override void OnParametersSet()
		{
			CurrentPaginationIndex = (CurrentPage - 1) / PaginationSize;

			IsPreviousButtonEnabled = CurrentPaginationIndex < 1;
			IsNextButtonEnabled = GetStartPage(CurrentPaginationIndex + 1) > TotalPages;

			StartPage = GetStartPage(CurrentPaginationIndex);
			EndPage = StartPage + Math.Min(PaginationSize, TotalPages - StartPage);
		}

		private async Task OnPageButtonClickAsync(int page)
		{
			if (OnClick.HasDelegate)
				await OnClick.InvokeAsync(page);
		}

		private int GetStartPage(int paginationIndex) => PaginationSize * paginationIndex + 1;
	}
}
