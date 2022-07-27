using System;
using System.Threading.Tasks;

namespace EgBlazorComponents.Spinner
{
	/// <summary>
	/// Spinner component.
	/// </summary>
	public partial class EgSpinner : EgComponentBase
	{
		#region Fields

		private bool showSpinner;
		private bool disposed;

		#endregion

		/// <summary>
		/// Show the spinner.
		/// </summary>
		/// <param name="action">The long running process</param>
		/// <returns>Async operation.</returns>
		public async Task ShowAsync(Func<Task> action)
		{
			Show(true);

			try
			{
				await action();
			}
			finally
			{
				Show(false);
			}
		}

		private void Show(bool show)
		{
			if (disposed)
				return;

			showSpinner = show;
			StateHasChanged();
		}

		public override void Dispose() => disposed = true;
	}
}
