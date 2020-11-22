using EgBlazorComponents.Table;

namespace EgBlazorComponents.Args
{
	public class TableCommandButtonArgs : IEventArgs
	{
		public EgCommandButton CommandButton { get; set; }
		public object Data { get; set; }

		public TableCommandButtonArgs(EgCommandButton commandButton, object data) => (CommandButton, Data) = (commandButton, data);
	}
}
