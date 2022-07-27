using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Globalization;

namespace EgBlazorComponents.Form
{
	/// <summary>
	/// Extension of <see cref="InputSelect{TValue}"/> component to support <see cref="Enum"/> type.
	/// </summary>
	/// <typeparam name="TEnum">Type parameter of <see cref="Enum"/>.</typeparam>
	public sealed class EgInputSelectEnum<TEnum> : InputBase<TEnum>
	{
		#region Override Methods

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			builder.OpenElement(0, "select");
			builder.AddMultipleAttributes(1, AdditionalAttributes);
			builder.AddAttribute(2, "class", CssClass);
			builder.AddAttribute(3, "value", BindConverter.FormatValue(CurrentValueAsString));
			builder.AddAttribute(4, "onchange", EventCallback.Factory.CreateBinder<string>(this, value => CurrentValueAsString = value, CurrentValueAsString));

			builder.OpenElement(5, "option");
			builder.AddAttribute(6, "value", "");
			builder.AddContent(7, "Choose...");
			builder.CloseElement();

			foreach (var value in Enum.GetValues(GetUnderlyingEnumType()))
			{
				builder.OpenElement(5, "option");
				builder.AddAttribute(6, "value", value.ToString());
				builder.AddContent(7, value.ToString());
				builder.CloseElement();
			}

			builder.CloseElement();
		}

		protected override bool TryParseValueFromString(string value, out TEnum result, out string validationErrorMessage)
		{
			if (BindConverter.TryConvertTo(value, CultureInfo.CurrentCulture, out TEnum parsedValue))
			{
				result = parsedValue;
				validationErrorMessage = null;
				return true;
			}

			result = default;
			validationErrorMessage = $"The {FieldIdentifier.FieldName} field is not valid.";
			return false;
		}

		#endregion Override Methods

		#region Private Methods

		private static Type GetUnderlyingEnumType() => Nullable.GetUnderlyingType(typeof(TEnum)) ?? typeof(TEnum);

		#endregion Private Methods
	}
}
