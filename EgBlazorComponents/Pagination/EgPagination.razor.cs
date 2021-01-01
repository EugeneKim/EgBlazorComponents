using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents.Pagination
{
	/// <summary>
	/// Pagination component.
	/// </summary>
	public partial class EgPagination : EgComponentBase
	{
		#region Fields

		private int currentPaginationIndex;
		private bool isPreviousButtonEnabled;
		private bool isNextButtonEnabled;
		private int startPage;
		private int numOfPages;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Total pages.
		/// </summary>
		[Parameter] public int TotalPages { get; set; }

		/// <summary>
		/// Page currently showing on the screen.
		/// The button on the pagination will be high-lighted.
		/// </summary>
		[Parameter] public int CurrentPage { get; set; }

		/// <summary>
		/// Size of the pagination.
		/// </summary>
		[Parameter] public int PaginationSize { get; set; } = 10;

		/// <summary>
		/// Click event handler.
		/// </summary>
		[Parameter] public EventCallback<int> OnClick { get; set; }

		#endregion Properties

		#region Override Methods

		protected override void OnParametersSet()
		{
			currentPaginationIndex = (CurrentPage - 1) / PaginationSize;

			isPreviousButtonEnabled = currentPaginationIndex < 1;
			isNextButtonEnabled = GetStartPage(currentPaginationIndex + 1) > TotalPages;

			startPage = GetStartPage(currentPaginationIndex);
			numOfPages = Math.Min(PaginationSize, TotalPages - startPage + 1);
		}

		#endregion Override Methods

		#region Private Methods

		private async Task OnPageButtonClickAsync(int page)
		{
			if (OnClick.HasDelegate)
				await OnClick.InvokeAsync(page);
		}

		private int GetStartPage(int paginationIndex) => PaginationSize * paginationIndex + 1;

		#endregion Private Methods
	}
}