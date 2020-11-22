namespace EgBlazorComponents.Args
{
	public class TableReadEventArgs : IEventArgs
	{
		public int Page { get; }

		public int PageSize { get; }

		public string Filter { get; }

		public TableReadEventArgs(int page, int pageSize, string filter) => (Page, PageSize, Filter) = (page, pageSize, filter);
	}
}
