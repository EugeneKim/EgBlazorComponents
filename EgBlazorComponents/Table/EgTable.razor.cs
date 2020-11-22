using EgBlazorComponents.Args;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EgBlazorComponents.Table
{
	public partial class EgTable : EgComponentBase
	{
		[Parameter] public EventCallback<TableReadEventArgs> OnRead { get; set; }

		[Parameter] public RenderFragment ChildContent { get; set; }

		[Parameter] public IReadOnlyList<object> DataContext { get; set; }

		[Parameter] public bool Searchable { get; set; }

		[Parameter] public bool Pageable { get; set; }

		[Parameter] public int PageSize { get; set; }

		[Parameter] public int Total { get; set; }

		public List<EgColumnBase> Columns { get; set; } = new();

		public int CurrentPage { get; set; } = 1;

		public int TotalPages
		{
			get
			{
				var totalPages = Total / PageSize;

				if (Total % PageSize > 0)
					totalPages++;

				return totalPages;
			}
		}

		public void AddColumn(EgColumnBase column) =>
			Columns.Add(column);

		private string filter = null;

		protected override void OnAfterRender(bool firstRender)
		{
			if (firstRender)
				StateHasChanged();
		}

		private async Task OnCommandButtonClickAsync(EgCommandButton commandButton, object data)
		{
			if (commandButton.OnClick.HasDelegate)
				await commandButton.OnClick.InvokeAsync(new TableCommandButtonArgs(commandButton, data));
		}

		public async Task SearchAsync(string value)
		{
			if (OnRead.HasDelegate)
			{
				CurrentPage = 1;
				filter = value;
				await OnRead.InvokeAsync(new TableReadEventArgs(CurrentPage, PageSize, filter));
				StateHasChanged();
			}
		}

		private async Task OnPaginationButtonClickAsync(int page)
		{
			if (OnRead.HasDelegate)
			{
				CurrentPage = page;
				await OnRead.InvokeAsync(new TableReadEventArgs(CurrentPage, PageSize, filter));
				StateHasChanged();
			}
		}
	}
}
