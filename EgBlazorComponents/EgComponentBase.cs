using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EgBlazorComponents
{
	public partial class EgComponentBase : ComponentBase, IDisposable, IAsyncDisposable
	{
		virtual public void Dispose() { }

		virtual public ValueTask DisposeAsync() =>
			ValueTask.CompletedTask;
	}
}
