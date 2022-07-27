using EgBlazorComponents.Table;

namespace EgBlazorComponents.Args
{
	/// <summary>
	/// Command arguments of a button inside the <see cref="EgTable"/>.
	/// </summary>
	public class TableCommandButtonArgs : IEventArgs
	{
		#region Properties

		/// <summary>
		/// A button bound to this arguments.
		/// </summary>
		public EgCommandButton CommandButton { get; set; }

		/// <summary>
		/// Model data associated with the button.
		/// </summary>
		public object Data { get; set; }

		#endregion Properties

		#region Construction

		public TableCommandButtonArgs(EgCommandButton commandButton, object data) => (CommandButton, Data) = (commandButton, data);

		#endregion Construction
	}
}
