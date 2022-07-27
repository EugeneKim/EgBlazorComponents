using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents
{
	/// <summary>
	/// Base class for a Blazor custom component.
	/// </summary>
	public partial class EgComponentBase : ComponentBase, IDisposable, IAsyncDisposable
	{
		#region Public Methods

		virtual public void Dispose() { }

		virtual public ValueTask DisposeAsync() => ValueTask.CompletedTask;

		#endregion Public Methods
	}
}
