﻿using EgBlazorComponents.Args;
using EgBlazorComponents.Demo.Models;
using EgBlazorComponents.Demo.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EgBlazorComponents.Demo.Pages
{
	public partial class EgTableExample : ComponentBase
	{
		[Inject] private WordsCollectionService WordCollectionService { get; set; }

		public IReadOnlyList<WordModel> WordData { get; set; }
		private int TotalWords { get; set; }
		public string Message { get; set; }
		private static int PageSize => 10;

		protected override async Task OnInitializedAsync() =>
			(TotalWords, WordData) = await WordCollectionService.GetWordsAsync(1, PageSize);

		public async Task OnReadAsync(TableReadEventArgs args) =>
			(TotalWords, WordData) = await WordCollectionService.GetWordsAsync(args.Page, args.PageSize, args.Filter);

		public async Task OnDeleteCommandButtonClickAsync(TableCommandButtonArgs args)
		{
			await Task.CompletedTask;
			Message = $"Command: Delete {(args.Data as WordModel)!.Word}";
		}

		public async Task OnEditCommandButtonClickAsync(TableCommandButtonArgs args)
		{
			await Task.CompletedTask;
			Message = $"Command: Edit {(args.Data as WordModel)!.Word}";
		}
	}
}
