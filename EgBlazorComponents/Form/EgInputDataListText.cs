using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Timers;

namespace EgBlazorComponents.Form
{
	public class EgInputDataListText : InputBase<string>
	{
		#region Fields

		private Timer debounceTimer;
		private IReadOnlyList<(string Value, string Content)> dataListItems;

		#endregion

		#region Properties

		[DisallowNull] public ElementReference? Element { get; protected set; }

		/// <summary>
		/// The delegate to subscribe to update with new data list items.
		/// </summary>
		[Parameter] public Func<string, IReadOnlyList<(string Value, string Content)>> OnNewListItemsRequested { get; set; }

		/// <summary>
		/// Length of the text to refresh the data list items.
		/// </summary>
		[Parameter] public int MinTextLengthForRefresh { get; set; } = 3;

		/// <summary>
		/// Limit the number of the data list items to be displayed.
		/// </summary>
		/// <remarks>
		/// This is a way to avoid any performance hit causing the UI slowness.
		/// </remarks>
		[Parameter] public int MaxDataListItemCount { get; set; } = 50;

		/// <summary>
		/// Timer interval for debouncing.
		/// </summary>
		[Parameter] public int DebounceInterval { get; set; } = 500;

		#endregion Properties

		#region Override Methods

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			var uniqueId = Guid.NewGuid().ToString();

			builder.OpenElement(1, "input");
			builder.AddMultipleAttributes(2, AdditionalAttributes);
			builder.AddAttribute(3, "class", CssClass);
			builder.AddAttribute(4, "value", BindConverter.FormatValue(CurrentValue));
			builder.AddAttribute(5, "list", uniqueId);
			builder.AddAttribute(6, "oninput", EventCallback.Factory.CreateBinder<string>(this, OnInputEventReceiver, CurrentValueAsString));
			builder.AddElementReferenceCapture(7, reference => Element = reference);
			builder.CloseElement();

			if (dataListItems != null && dataListItems.Any())
			{
				builder.OpenElement(8, "datalist");
				builder.AddAttribute(9, "id", uniqueId);

				foreach (var item in dataListItems.Take(MaxDataListItemCount))
				{
					builder.OpenElement(10, "option");
					builder.AddAttribute(11, "value", item.Value);
					builder.AddContent(12, item.Content);
					builder.CloseElement();
				}

				builder.CloseElement();
			}
		}

		protected override bool TryParseValueFromString(string value, out string result, [NotNullWhen(false)] out string validationErrorMessage)
		{
			result = value;
			validationErrorMessage = null;
			return true;
		}

		protected override void Dispose(bool disposing) => debounceTimer?.Dispose();

		#endregion Override Methods

		#region Private Methods

		private void OnInputEventReceiver(string value)
		{
			debounceTimer?.Stop();

			if (value.Trim().Length >= MinTextLengthForRefresh)
			{
				debounceTimer = new Timer();
				debounceTimer.AutoReset = false;
				debounceTimer.Elapsed += (_, _) =>
				{
					InvokeAsync(() =>
					{
						dataListItems = OnNewListItemsRequested(value);
						CurrentValueAsString = value;
					});
				};
				debounceTimer.Interval = DebounceInterval;
				debounceTimer.Start();
			}
			else
				dataListItems = null;
		}

		#endregion Private Methods
	}
}