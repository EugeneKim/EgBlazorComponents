using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents
{
	/// <summary>
	/// Base class for a Blazor custom component.
	/// </summary>
	public class EgComponentBase : ComponentBase, IDisposable, IAsyncDisposable
	{
		#region Public Methods

		public virtual void Dispose() { }

		public virtual ValueTask DisposeAsync() => ValueTask.CompletedTask;

		#endregion Public Methods
	}
}
