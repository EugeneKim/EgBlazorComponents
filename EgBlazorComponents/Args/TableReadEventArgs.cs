using EgBlazorComponents.Table;

namespace EgBlazorComponents.Args
{
	/// <summary>
	/// Arguments containing information on a partial loading and used by <see cref="EgTable.OnRead"/>.
	/// </summary>
	public class TableReadEventArgs : IEventArgs
	{
		#region Properties

		/// <summary>
		/// Current page.
		/// </summary>
		public int Page { get; }

		/// <summary>
		/// Size of the page.
		/// </summary>
		public int PageSize { get; }

		/// <summary>
		/// Filter.
		/// </summary>
		public string Filter { get; }

		#endregion Properties

		#region Construction

		public TableReadEventArgs(int page, int pageSize, string filter) => (Page, PageSize, Filter) = (page, pageSize, filter);

		#endregion Construction
	}
}
